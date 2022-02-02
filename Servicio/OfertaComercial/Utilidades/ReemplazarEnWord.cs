using Word = Microsoft.Office.Interop.Word;
using Model;

namespace Servicios.OfertaComercial.Utilidades
{
    public class ReemplazarEnWord
    {    
        public void TextoGeneral(string bookmark, string valorReemplazo, Word.Document docof, string strPrevio = "", string strPosterior = "", int bold = 0)
        {
            Word.Bookmarks wBookmarks = docof.Bookmarks;
            Word.Bookmark wBookmark = wBookmarks[bookmark];
            Word.Range wRange = wBookmark.Range;
            wRange.Font.Bold = bold;
            wRange.Text = (!string.IsNullOrEmpty(valorReemplazo)) ? strPrevio + valorReemplazo + strPosterior : "";
        }

        public void Vendedores(int NVendedor, Usuario Usuario, Word.Document docof, string strPrevio = "", string strPosterior = "")
        {
            if (Usuario == null) { return; }
            TextoGeneral("Vendedor" + NVendedor, Usuario.ToString(), docof);
            TextoGeneral("TelefonoVendedor" + NVendedor, Usuario.Telefono, docof);
            TextoGeneral("CelularVendedor" + NVendedor, Usuario.Celular, docof);
            TextoGeneral("EmailVendedor" + NVendedor, Usuario.Mail, docof);
            TextoGeneral("CargoVendedor" + NVendedor, Usuario.Cargo, docof);
            if (Usuario.IdBU != 0)
            {
                if (Usuario.IdBU == 4) { TextoGeneral("UnidadVendedor" + NVendedor, "Howden South America", docof); }
                else if (Usuario.IdBU == 8) { TextoGeneral("UnidadVendedor" + NVendedor, "Howden Chile", docof); }
                else if (Usuario.IdBU == 22) { TextoGeneral("UnidadVendedor" + NVendedor, "Howden South Perú", docof); }
                else { TextoGeneral("UnidadVendedor" + NVendedor, "", docof); }
            }
        }
    }
}
