using System;
using Model;
using Word = Microsoft.Office.Interop.Word;

namespace Servicios.OfertaComercial
{
    public class InfoBanco
    {
        public void Agregar(Oferta Oferta, BU Unidad, Word.Document docof)
        {
            Word.Bookmarks wBookmarks = docof.Bookmarks;
            Word.Bookmark wBookmark = wBookmarks["Moneda"];
            Word.Range wRange = wBookmark.Range;            

            var curr = (MonedasEnum)Oferta.IdMoneda;
            string Curr = curr.ToString();

            if (!String.IsNullOrEmpty(Curr))
            {
                ReemplazarEnWord.textoGeneral("Curr", Curr, docof, bold: 1);
                ReemplazarEnWord.textoGeneral("Curr2", Curr, docof, bold: 1);
                ReemplazarEnWord.textoGeneral("Curr3", Curr, docof, bold: 1);

                if (Oferta.IdBU == (int)BUEnum.HCHL)
                {
                    ReemplazarEnWord.textoGeneral("TipoIDTrib", "RUT: ", docof);
                    ReemplazarEnWord.textoGeneral("IDTrib", Unidad.IdTributario, docof, bold: 1);
                    ReemplazarEnWord.textoGeneral("Banco", "HSBC Bank Chile", docof, bold: 1);

                    if ((int)MonedasEnum.CLP == Oferta.IdMoneda)
                    {
                        wRange.Text = "Peso Chileno - CLP";
                        for (int i = 0; i < 19; i++) { docof.Tables[6].Rows[5].Delete(); }
                    }
                    else if ((int)MonedasEnum.EUR == Oferta.IdMoneda)
                    {
                        wRange.Text = "Euro - EUR"; 
                        for (int i = 0; i < 4; i++) { docof.Tables[6].Rows[1].Delete(); }
                        for (int i = 0; i < 12; i++) { docof.Tables[6].Rows[8].Delete(); }
                    }
                    else if ((int)MonedasEnum.USD == Oferta.IdMoneda || (int)MonedasEnum.GBP == Oferta.IdMoneda)
                    {
                        wRange.Text = (Oferta.Idioma == "Esp") ? "Dólar Americano - USD" : "American Dollar - USD";
                        for (int i = 0; i < 11; i++) { docof.Tables[6].Rows[1].Delete(); }
                        for (int i = 0; i < 4; i++) { docof.Tables[6].Rows[9].Delete(); }
                    }
                }
                else if (Oferta.IdBU == (int)BUEnum.HPU)
                {
                    ReemplazarEnWord.textoGeneral("TipoIDTrib", "RUC: ", docof);
                    ReemplazarEnWord.textoGeneral("IDTrib", Unidad.IdTributario, docof, bold: 1);
                    ReemplazarEnWord.textoGeneral("Banco", "Santander", docof, bold: 1);

                    if ((int)MonedasEnum.PEN == Oferta.IdMoneda)
                    {
                        wRange.Text = "Nuevo Sol peruano - SOL";
                        for (int i = 0; i < 20; i++) { docof.Tables[6].Rows[1].Delete(); }
                        docof.Tables[6].Rows[4].Delete();
                    }
                    else 
                    {
                        wRange.Text = (Oferta.Idioma == "Esp") ? "Dólar Americano - USD" : "American Dollar - USD";
                        for (int i = 0; i < 20; i++) { docof.Tables[6].Rows[1].Delete(); }
                        docof.Tables[6].Rows[3].Delete();
                    }
                }
            }
        }
    }
}
