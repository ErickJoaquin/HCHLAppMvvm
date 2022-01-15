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
    public class Representantes
    {
        private readonly RepresentantesDic _infoRepresentantes;
        public Representantes(RepresentantesDic infoRepresentantes)
        {
            this._infoRepresentantes = infoRepresentantes;
        }

        public string Agregar(Oferta Oferta, OfertaClientes ofClientes, List<ContactoCliente> CctosRepresentantes, string body)
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
                Dictionary<string, string> contactosDic = _infoRepresentantes.TraerInformacion(CctosRepresentantes);
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
    }
}
