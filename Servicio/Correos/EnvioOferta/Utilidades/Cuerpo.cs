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
    public class Cuerpo
    {     
        private readonly Representantes _reps;
        private readonly Vendedores _vendedores;
        public Cuerpo(Representantes reps, Vendedores vendedores)
        {
            this._reps = reps;
            this._vendedores = vendedores;
        }

        public string Agregar(Oferta Oferta, OfertaClientes ofClientes, ContactoCliente CtoCliente, List<ContactoCliente> CtosRepresentantes, 
            List<Usuario> vendedoresOferta, bool incluyeRep)
        {
            string body = "";

            if (Oferta.Idioma == "Ing")
            {
                body = $"<HTML><BODY><FONT face=Arial color=#1F497D size=2>Dear {CtoCliente.Nombres}, <br/> <br/>";
                body += $"Please see attached our Commercial Proposal {Oferta.NCRM}-{Oferta.Rev} for your evaluation; <br/> <br/>";

                body += "For further information on delivery, technical or commercial subjects, please contact: <br/><br/>";
                if (incluyeRep) { _reps.Agregar(Oferta, ofClientes, CtosRepresentantes, body); }
                _vendedores.Agregar(Oferta, body, vendedoresOferta);
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
                if (incluyeRep) { _reps.Agregar(Oferta, ofClientes, CtosRepresentantes, body); }
                _vendedores.Agregar(Oferta, body, vendedoresOferta);
                body += "El precio de venta presentado en nuestra oferta está condicionado a la aceptación de las 'Condiciones de Suministro' generales de Howden, " +
                    "presentes al final de la misma. Cualquier otra condición diferente está sujeta a renegociación comercial. <br/> <br/>";
                body += "Nuevamente agradecemos su atención y nos quedamos a disposición para aclaraciones. <br/> <br/> <br/>";
                body += "Saludos cordiales, <br/> <br/>";
            }
            return body;
        }
    }
}
