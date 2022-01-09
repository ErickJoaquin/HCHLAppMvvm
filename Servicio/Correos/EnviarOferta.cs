using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Data;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.IO;
using System.Windows.Forms;

namespace Servicios.Correos
{
    public class EnviarOferta
    {
        public static void Crear(Oferta Oferta, OfertaClientes ofClientes, Mercado mercado, bool incluyeRep)
        {
            RepositorioBase<Usuario> repUser = new RepositorioBase<Usuario>();
            List<int> aObtener = new List<int>() { mercado.IdKAM, mercado.IdKA, mercado.IdVendedor1, mercado.IdVendedor2, mercado.IdVendedor3 };
            List<Usuario> vendedoresOferta = repUser.GetMultiIdAsync(aObtener).Result;

            RepositorioBase<ContactoCliente> repCcto = new RepositorioBase<ContactoCliente>();
            ContactoCliente CtoCliente = repCcto.GetByIdAsync(ofClientes.IdContacto).Result;

            RepositorioContactos repCtps = new RepositorioContactos();
            List<ContactoCliente> CtosRepresentantes = repCtps.GetAllByClientIdAsync(ofClientes.IdRep1, (int)VendorEUEnum.Vendor).Result;

            string body = agregarCuerpo(Oferta, ofClientes, CtoCliente, CtosRepresentantes, vendedoresOferta, incluyeRep);

            Outlook.Application app = new Outlook.Application();
            Outlook.MailItem mailSelected = app.ActiveExplorer().Selection[1];
            Outlook.MailItem mailReply = null;
            if (mailSelected == null) { mailReply = app.CreateItem(Outlook.OlItemType.olMailItem); }
            else { mailReply = mailSelected.ReplyAll(); }
            
            mailReply.HTMLBody = body + mailReply.HTMLBody + mailSelected.HTMLBody;

            detallesRespuesta(mailReply, mailSelected, vendedoresOferta, Oferta, ofClientes, CtoCliente, CtosRepresentantes);
            adjuntaOferta(Oferta, mailReply);

            mailReply.Display();
        }
                     
        private static string agregarCuerpo(Oferta Oferta, OfertaClientes ofClientes, ContactoCliente CtoCliente, List<ContactoCliente> CtosRepresentantes, List<Usuario> vendedoresOferta, bool incluyeRep)
        {
            string body = "";

            if (Oferta.Idioma == "Ing")
            {
                body = $"<HTML><BODY><FONT face=Arial color=#1F497D size=2>Dear {CtoCliente.Nombres}, <br/> <br/>";
                body += $"Please see attached our Commercial Proposal {Oferta.NCRM}-{Oferta.Rev} for your evaluation; <br/> <br/>";

                body += "For further information on delivery, technical or commercial subjects, please contact: <br/><br/>";
                if (incluyeRep) { agregarRepresentante(Oferta, ofClientes, CtosRepresentantes, body); }
                agregarVendedores(Oferta, body, vendedoresOferta);
                body += "The sales price presented in our offer is conditioned to accept the 'Standard terms & conditions for the sale of goods' standard Howden, " +
                    "contained in our offer. Any difference in condition is subject to the commercial renegotiation. <br/> <br/>";
                body += "Thanks for quoting with Howden. We remain available for any clarification it may be necessary.. <br/> <br/> <br/>";
                body += "Best regards, <br/> <br/>";
            }
            else if (Oferta.Idioma == "Por")
            {

            }
            else
            {
                body = (CtoCliente.Sexo == "M") ? $"<HTML><BODY><FONT face=Arial color=#1F497D size=2>Estimada {CtoCliente.Nombres}, <br/> <br/>" :
                    $"<HTML><BODY><FONT face=Arial color=#1F497D size=2>Estimado {CtoCliente.Nombres}, <br/> <br/>";
                body += "Agradecidos por su preferencia y confianza en nosotros,  <br/>";
                body += $"En representación de Howden tengo el agrado de enviar nuestra oferta económica {Oferta.NCRM}-{Oferta.Rev} en respuesta a su " +
                    "requerimiento en adjunto; <br/> <br/>";
                body += "Para marcar una visita, para temas técnicos y/o comerciales, solicitamos contactar a: <br/> <br/>";
                if (incluyeRep) { agregarRepresentante(Oferta, ofClientes, CtosRepresentantes, body); }
                agregarVendedores(Oferta, body, vendedoresOferta);
                body += "El precio de venta presentado en nuestra oferta está condicionado a la aceptación de las 'Condiciones de Suministro' generales de Howden, " +
                    "presentes al final de la misma. Cualquier otra condición diferente está sujeta a renegociación comercial. <br/> <br/>";
                body += "Nuevamente agradecemos su atención y nos quedamos a disposición para aclaraciones. <br/> <br/> <br/>";
                body += "Saludos cordiales, <br/> <br/>";
            }
            return body;
        }

        private static string agregarVendedores(Oferta Oferta, string body, List<Usuario> vendedoresOferta)
        {
            string nombrekam = vendedoresOferta.ElementAt(0).NombreCompleto;
            string mailkam = vendedoresOferta.ElementAt(0).Mail;
            string telefonokam = vendedoresOferta.ElementAt(0).Telefono;
            string celularkam = vendedoresOferta.ElementAt(0).Celular;
            string nombreka = (vendedoresOferta.Count > 1) ? vendedoresOferta.ElementAt(1).NombreCompleto : "";
            string mailka = (vendedoresOferta.Count > 1) ? vendedoresOferta.ElementAt(1).Mail : "";
            string telefonoka = (vendedoresOferta.Count > 1) ? vendedoresOferta.ElementAt(1).Telefono : "";
            string celularka = (vendedoresOferta.Count > 1) ? vendedoresOferta.ElementAt(1).Celular : "";
            string nombrevend = (vendedoresOferta.Count > 2) ? vendedoresOferta.ElementAt(2).NombreCompleto : "";
            string mailvend = (vendedoresOferta.Count > 2) ? vendedoresOferta.ElementAt(2).Mail : "";
            string telefonovend = (vendedoresOferta.Count > 2) ? vendedoresOferta.ElementAt(2).Telefono : "";
            string celularvend = (vendedoresOferta.Count > 2) ? vendedoresOferta.ElementAt(2).Celular : "";

            if (nombrevend != "") { body += $"<b> {nombrevend}:</b> {telefonovend} / {celularvend} - {mailvend}.<br/>"; }
            if (nombreka != "") { body += $"<b> {nombreka}:</b> {telefonoka} / {celularka} - {mailka}.<br/>"; }
            body += $"<b> {nombrekam}:</b> {telefonokam} / {celularkam} - {mailkam}.<br/>";
            body += (vendedoresOferta.Count > 2) ? "<br/>" : "<b> Edson Luis Geraldini:</b> +55 11 4487 6252 / +55 11 98193 6392 - edson.geraldini@howden.com. <br/> <br/>";

            return body;
        }

        private static string agregarRepresentante(Oferta Oferta, OfertaClientes ofClientes, List<ContactoCliente> CctosRepresentantes, string body)
        {
            if (String.IsNullOrEmpty(ofClientes.IdRep1.ToString())) 
            { 
                MessageBox.Show("Seleccionó incluir representante en esta oferta, pero no a señalado ningún representante. " +
                "Por favor, seleccione uno o seleccione el botón 'No' para no incluir representantes"); 
                return null; 
            }
                        
            int NCctos = CctosRepresentantes.Count();
            
            if (NCctos > 0)
            {
                Dictionary<string, string> contactosDic = infoRepresentantes(CctosRepresentantes);
                string representante = "";

                if (Oferta.Idioma == "Ing")
                {
                    representante = $"Sales representative, ";
                }
                else if (Oferta.Idioma == "Por")
                {

                }
                else
                {
                    representante = $"Representante de ventas, ";
                }
                body += $"<b>{ contactosDic["nombrerep"]}: </b>{ contactosDic["telefonorep"]} / {contactosDic["celularrep"]} - {contactosDic["mailrep"]}. <br/> <br/>";
            }
            return body;
        }

        private static Dictionary<string, string> infoRepresentantes( List<ContactoCliente> CctosRepresentantes)
        {
            string representantemail = "";
            string nombrerep = ""; string mailrep = ""; string telefonorep = ""; string celularrep = "";
            Dictionary<string, string> DicRepresentantes = new Dictionary<string, string>();

            for (int i = 0; i < CctosRepresentantes.Count(); i++)
            {
                if (i == 0)
                {
                    nombrerep = (CctosRepresentantes[i].Telefono.ToString() != null && CctosRepresentantes[i].NombreCompleto.ToString() != "") ? CctosRepresentantes[i].NombreCompleto : "";
                    telefonorep = (CctosRepresentantes[i].Telefono.ToString() != null && CctosRepresentantes[i].Telefono.ToString() != "") ? CctosRepresentantes[i].Telefono : "";
                    celularrep = (CctosRepresentantes[i].Celular != null) ? CctosRepresentantes[i].Celular : "";
                    mailrep = (CctosRepresentantes[i].Mail != null) ? CctosRepresentantes[i].Mail : "";
                    representantemail = (CctosRepresentantes[i].Mail != null) ? CctosRepresentantes[i].Mail : "";
                }
                else
                {
                    if (nombrerep == "") { nombrerep += (CctosRepresentantes[i].NombreCompleto.ToString() != null && CctosRepresentantes[i].NombreCompleto.ToString() != "") ? CctosRepresentantes[i].NombreCompleto : ""; }
                    else { nombrerep += (CctosRepresentantes[i].NombreCompleto.ToString() != null && CctosRepresentantes[i].NombreCompleto.ToString() != "") ? "/" + CctosRepresentantes[i].NombreCompleto : ""; }
                    if (telefonorep == "") { telefonorep += (CctosRepresentantes[i].Telefono.ToString() != null && CctosRepresentantes[i].Telefono.ToString() != "") ? CctosRepresentantes[i].Telefono : ""; }
                    else if (CctosRepresentantes[i].Telefono != CctosRepresentantes[i - 1].Telefono) { telefonorep += (CctosRepresentantes[i].Telefono.ToString() != null && CctosRepresentantes[i].Telefono.ToString() != "") ? "/" + CctosRepresentantes[i].Telefono : ""; }
                    if (celularrep == "") { celularrep += (CctosRepresentantes[i].Celular.ToString() != null && CctosRepresentantes[i].Celular.ToString() != "") ? CctosRepresentantes[i].Celular : ""; }
                    else if (CctosRepresentantes[i].Celular != CctosRepresentantes[i - 1].Celular) { celularrep += (CctosRepresentantes[i].Celular != null) ? "/" + CctosRepresentantes[i].Celular : ""; }
                    if (mailrep == "")
                    {
                        mailrep += (CctosRepresentantes[i].Mail != null) ? CctosRepresentantes[i].Mail : "";
                        representantemail = (CctosRepresentantes[i].Mail != null) ? CctosRepresentantes[i].Mail : "";
                    }
                    else if (CctosRepresentantes[i].Mail != CctosRepresentantes[i - 1].Mail)
                    {
                        mailrep += (CctosRepresentantes[i].Mail.ToString() != null && CctosRepresentantes[i].Mail.ToString() != "") ? "/" + CctosRepresentantes[i].Mail : "";
                        representantemail += (CctosRepresentantes[i].Mail.ToString() != null && CctosRepresentantes[i].Mail.ToString() != "") ? "; " + CctosRepresentantes[i].Mail : "";
                    }
                }
            }

            DicRepresentantes.Add("nombrerep", nombrerep);
            DicRepresentantes.Add("telefonorep", telefonorep);
            DicRepresentantes.Add("celularrep", celularrep);
            DicRepresentantes.Add("mailrep", mailrep);
            DicRepresentantes.Add("representantemail", representantemail);

            return DicRepresentantes;
        }

        private static void detallesRespuesta(Outlook.MailItem mailReply, Outlook.MailItem mailSelected, List<Usuario> vendedoresOferta, Oferta Oferta, OfertaClientes ofClientes,
            ContactoCliente Contacto, List<ContactoCliente> CctosRepresentantes)
        {
            Dictionary<string, string> contactosDic = infoRepresentantes(CctosRepresentantes);

            mailReply.Subject = $"HOWDEN - Oferta Económica {Oferta.NCRM}-{Oferta.Rev} / {mailSelected.Subject}";

            mailReply.To = mailReply.To.Contains(Contacto.Mail) ? mailReply.To : Contacto.Mail;
            mailReply.CC = "edson.geraldini@howden.com; marcos.pinto@howden.com; thais.trevine@howden.com; ";
            mailReply.CC += mailReply.To.Trim().Contains(vendedoresOferta.ElementAt(0).Mail) ? ""
                : "; " + vendedoresOferta.ElementAt(0).Mail;

            if (!String.IsNullOrEmpty(vendedoresOferta.ElementAt(1).Mail) && !mailReply.To.Trim().Contains(vendedoresOferta.ElementAt(1).Mail))
            {
                mailReply.CC +=  "; " + vendedoresOferta.ElementAt(1).Mail;
            }
            if (!String.IsNullOrEmpty(vendedoresOferta.ElementAt(2).Mail) && !mailReply.To.Trim().Contains(vendedoresOferta.ElementAt(2).Mail))
            {
                mailReply.CC += "; " + vendedoresOferta.ElementAt(2).Mail;
            }
            if (!String.IsNullOrEmpty(contactosDic["representantemail"]) && !mailReply.To.Trim().Contains(contactosDic["representantemail"])) 
            {
                mailReply.CC += "; " + contactosDic["representantemail"]; 
            }
        }

        private static Outlook.MailItem adjuntaOferta(Oferta Oferta, Outlook.MailItem mailReply)
        {
            RepositorioCarpetas repCarpetas = new RepositorioCarpetas();
            string rutaoferta = repCarpetas.GetPathAsync(Oferta.IdBU, "comercialOferta").Result;

            if (String.IsNullOrEmpty(Oferta.NCRM.ToString()) || String.IsNullOrEmpty(Oferta.Rev.ToString()))
            {
                MessageBox.Show($"No se encontró la oferta {rutaoferta}, debido a un problema en la generación del nombre de la ruta");
                return mailReply;
            }
            else { rutaoferta += $"P_{Oferta.NCRM}-R{Oferta.Rev}.pdf"; }

            if (File.Exists(rutaoferta)) { mailReply.Attachments.Add(rutaoferta); }
            else
            {
                MessageBox.Show($"No se encontró ningún archivo para adjuntar con la ruta: {rutaoferta}. " +
                    "Revise que el archivo esté guardado correctamente en la carpeta de Propuestas. " +
                    "Si el error continúa, comuniquese con el administrador.");
            };

            return mailReply;
        }
    }
}
