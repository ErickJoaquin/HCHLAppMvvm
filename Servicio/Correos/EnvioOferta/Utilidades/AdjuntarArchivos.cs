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
    public class AdjuntarArchivos
    {
        private readonly RepositorioCarpetas _repCarpetas;
        public AdjuntarArchivos(RepositorioCarpetas repCarpetas)
        {
            this._repCarpetas = repCarpetas;
        }
        public Outlook.MailItem Oferta(Oferta Oferta, Outlook.MailItem mailReply)
        {
            string rutaoferta = _repCarpetas.GetPathAsync(Oferta.IdBU, "comercialOferta").Result;

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
