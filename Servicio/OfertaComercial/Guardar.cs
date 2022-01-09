using System;
using System.Windows.Forms;
using Data;
using Model;
using Word = Microsoft.Office.Interop.Word;

namespace Servicios.OfertaComercial
{
    public class Guardar
    {
        public static void wordPDF(Oferta Oferta, Word.Document docof, bool Consolidando)
        {
            RepositorioCarpetas repPasta = new RepositorioCarpetas();
            string rutaoferta = repPasta.GetPathAsync((int)BUEnum.HCHL, "comercialOferta").Result;   //o pruebaOfertas

            if (String.IsNullOrEmpty(Oferta.NCRM) || String.IsNullOrEmpty(Oferta.Rev.ToString())) 
            { 
                MessageBox.Show($"No se puedo guardar la oferta en la carpeta {rutaoferta}, debido a un problema en la generacioón del nombre de esta"); 
                return; 
            }
            else
            {
                rutaoferta += $"P_{Oferta.NCRM}-R{Oferta.Rev}";
                if (Consolidando) { rutaoferta += "_Consolidada"; }
            }

            docof.SaveAs(rutaoferta + ".docx");
            object fileFormat = Word.WdSaveFormat.wdFormatPDF;
            docof.SaveAs2(rutaoferta + ".pdf", ref fileFormat);
        }
    }
}
