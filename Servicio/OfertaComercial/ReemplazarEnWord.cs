using Word = Microsoft.Office.Interop.Word;
using Model;

namespace Servicios.OfertaComercial
{
    public class ReemplazarEnWord
    {    
        public static void textoGeneral(string bookmark, string valorReemplazo, Word.Document docof, string strPrevio = "", string strPosterior = "", int bold = 0)
        {
            Word.Bookmarks wBookmarks = docof.Bookmarks;
            Word.Bookmark wBookmark = wBookmarks[bookmark];
            Word.Range wRange = wBookmark.Range;
            wRange.Font.Bold = bold;
            wRange.Text = (!string.IsNullOrEmpty(valorReemplazo)) ? strPrevio + valorReemplazo + strPosterior : "";
        }

        public static void vendedores(int NVendedor, Usuario Usuario, Word.Document docof, string strPrevio = "", string strPosterior = "")
        {
            if (Usuario == null) { return; }
            textoGeneral("Vendedor" + NVendedor, Usuario.NombreCompleto, docof);
            textoGeneral("TelefonoVendedor" + NVendedor, Usuario.Telefono, docof);
            textoGeneral("CelularVendedor" + NVendedor, Usuario.Celular, docof);
            textoGeneral("EmailVendedor" + NVendedor, Usuario.Mail, docof);
            textoGeneral("CargoVendedor" + NVendedor, Usuario.Cargo, docof);
            if (Usuario.IdBU != 0)
            {
                if (Usuario.IdBU == 4) { textoGeneral("UnidadVendedor" + NVendedor, "Howden South America", docof); }
                else if (Usuario.IdBU == 8) { textoGeneral("UnidadVendedor" + NVendedor, "Howden Chile", docof); }
                else if (Usuario.IdBU == 22) { textoGeneral("UnidadVendedor" + NVendedor, "Howden South Perú", docof); }
                else { textoGeneral("UnidadVendedor" + NVendedor, "", docof); }
            }
        }
    }
}
