using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Data;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.IO;
using System.Windows.Forms;

namespace Servicios.Correos.EnvioOferta.Utilidades
{
    public class DetallesCorreo
    {
        private readonly RepresentantesDic _representantes;
        public DetallesCorreo(RepresentantesDic representantes)
        {
            this._representantes = representantes;
        }

        public void Agregar(Outlook.MailItem mailReply, Outlook.MailItem mailSelected, List<Usuario> vendedoresOferta, Oferta Oferta, OfertaClientes ofClientes,
            ContactoCliente Contacto, List<ContactoCliente> CctosRepresentantes)
        {
            Dictionary<string, string> contactosDic = _representantes.TraerInformacion(CctosRepresentantes);

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
    }
}
