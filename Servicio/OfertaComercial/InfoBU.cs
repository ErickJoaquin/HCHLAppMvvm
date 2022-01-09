using System;
using Model;
using Word = Microsoft.Office.Interop.Word;

namespace Servicios.OfertaComercial
{
    public class InfoBU
    {
        public void Agregar(Oferta Oferta, BU Unidad, Word.Document docof)
        {
            if (String.IsNullOrEmpty((Unidad.Id).ToString())) { return; }
            
            ReemplazarEnWord.textoGeneral("Unidad2", Unidad.Nombre, docof, bold: 1);
            ReemplazarEnWord.textoGeneral("TelefonoBU", Unidad.Telefono, docof);
            ReemplazarEnWord.textoGeneral("DireccionBU", Unidad.Direccion, docof);
            ReemplazarEnWord.textoGeneral("DireccionBU2", Unidad.Direccion, docof);
            ReemplazarEnWord.textoGeneral("DireccionBU3", Unidad.Direccion, docof);
            ReemplazarEnWord.textoGeneral("DireccionBU4", Unidad.Direccion, docof, bold: 1);

            if (Oferta.IdBU == (int)BUEnum.HSA)
            {
                ReemplazarEnWord.textoGeneral("BU", "South America", docof, bold: 1);
                ReemplazarEnWord.textoGeneral("Unidad", "Howden South America", docof, bold: 1);
            }
            else if (Oferta.IdBU == (int)BUEnum.HCHL)
            {
                ReemplazarEnWord.textoGeneral("BU", "Chile", docof, bold: 1);
                ReemplazarEnWord.textoGeneral("Unidad", "Howden Chile S.p.A.", docof, bold: 1);
            }
            else if (Oferta.IdBU == (int)BUEnum.HPU)
            {
                ReemplazarEnWord.textoGeneral("BU", "Perú ", docof, bold: 1);
                ReemplazarEnWord.textoGeneral("Unidad", "Howden Perú S.R.L.", docof, bold: 1);
            }
            else { ReemplazarEnWord.textoGeneral("BU", "", docof); }
        }
    }
}
