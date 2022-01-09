﻿using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Data;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace Servicios.OfertaComercial
{
    public class InfoRepresentantes
    {
        public void Agregar(OfertaClientes ofClientes, string idioma, bool incluyeRep, Word.Document docof)
        {
            RepositorioContactos repCC = new RepositorioContactos();
            List<ContactoCliente> ListaCctos = repCC.GetAllByClientIdAsync(ofClientes.IdRep1, (int)VendorEUEnum.Vendor).Result;

            if (!incluyeRep) 
            { 
                ReemplazarEnWord.textoGeneral("Rep", "", docof); 
                ReemplazarEnWord.textoGeneral("RepContacto", "", docof); 
                ReemplazarEnWord.textoGeneral("Repdatos", "", docof);
                return;
            }

            if (String.IsNullOrEmpty(ofClientes.IdRep1.ToString())) 
            { 
                MessageBox.Show("Seleccionó incluir representante en esta oferta, pero no a señalado ningún representante. " +
                    "Por favor, seleccione uno o seleccione el botón 'No' para no incluir representantes"); 
                return; 
            }

            int NCctos = ListaCctos.Count();

            if (NCctos > 0)
            {
                string telefono = ""; string celular = ""; string nombres = ""; string mail = "";

                string pres = 
                    (idioma == "Ing") ? "For any extra information or clarification please contact our sales representative: " :
                    (idioma == "Por") ? "" :
                    "Para cualquier aclaración o información adicional, comuníquese con nuestro representante de ventas: ";
                ReemplazarEnWord.textoGeneral("Rep", pres, docof);

                foreach (ContactoCliente rep in ListaCctos)
                {
                    if (nombres == "") { nombres += (rep.NombreCompleto.ToString() != null && rep.NombreCompleto.ToString() != "") ? rep.NombreCompleto.Trim() : ""; }
                    else if (!nombres.Contains(rep.NombreCompleto)) { nombres += (rep.NombreCompleto.ToString() != null && rep.NombreCompleto.ToString() != "") ? "/" + rep.NombreCompleto.Trim() : ""; }
                    if (telefono == "") { telefono += (rep.Telefono.ToString() != null && rep.Telefono.ToString() != "") ? rep.Telefono : ""; }
                    else if (!telefono.Contains(rep.Telefono)) { telefono += (rep.Telefono.ToString() != null && rep.Telefono.ToString() != "") ? "/" + rep.Telefono : ""; }
                    if (celular == "") { celular += (rep.Celular.ToString() != null && rep.Celular.ToString() != "") ? rep.Celular : ""; }
                    else if (!celular.Contains(rep.Celular)) { celular += (rep.Celular.ToString() != null && rep.Celular.ToString() != "") ? "/" + rep.Celular : ""; }
                    if (mail == "") { mail += (rep.Mail.ToString() != null && rep.Mail.ToString() != "") ? rep.Mail : ""; }
                    else if (!mail.Contains(rep.Mail)) { mail += (rep.Mail.ToString() != null && rep.Mail.ToString() != "") ? "/" + rep.Mail : ""; }
                }

                ReemplazarEnWord.textoGeneral("RepContacto", nombres.Trim(), docof, "", " - ", bold: 1);
                string datos = (mail != "") ? $"email: {mail.Trim()}" : "";
                datos += (telefono != "" && idioma == "Esp") ? "; teléfono: " + telefono.Trim() : (telefono != "") ? "; phone " + telefono.Trim() : "";
                datos += (celular != "" && idioma == "Esp") ? "; celular: " + celular.Trim() : (celular != "") ? "; mobil: " + celular : "";
                datos += ".";
                ReemplazarEnWord.textoGeneral("RepDatos", datos, docof);
            }

        }
    }
}
