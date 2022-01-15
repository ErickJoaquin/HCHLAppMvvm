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
    public class RepresentantesDic
    {
        public Dictionary<string, string> DicRepresentantes;

        public RepresentantesDic()
        {
            DicRepresentantes = new Dictionary<string, string>();
        }

        public Dictionary<string, string> TraerInformacion(List<ContactoCliente> CctosRepresentantes)
        {
            string representantemail = ""; string nombrerep = ""; string mailrep = ""; string telefonorep = ""; string celularrep = "";

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
    }
}
