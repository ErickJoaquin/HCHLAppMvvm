using System;
using Model;
using Word = Microsoft.Office.Interop.Word;
using Servicios.OfertaComercial.Utilidades;

namespace Servicios.OfertaComercial.Informacion
{
    public class InfoBU
    {
        private readonly ReemplazarEnWord _reemplazar;
        public InfoBU(ReemplazarEnWord reemplazar)
        {
            this._reemplazar = reemplazar;
        }
        public void Agregar(Oferta Oferta, BU Unidad, Word.Document docof)
        {
            if (String.IsNullOrEmpty((Unidad.Id).ToString())) { return; }

            _reemplazar.TextoGeneral("Unidad2", Unidad.Nombre, docof, bold: 1);
            _reemplazar.TextoGeneral("TelefonoBU", Unidad.Telefono, docof);
            _reemplazar.TextoGeneral("DireccionBU", Unidad.Direccion, docof);
            _reemplazar.TextoGeneral("DireccionBU2", Unidad.Direccion, docof);
            _reemplazar.TextoGeneral("DireccionBU3", Unidad.Direccion, docof);
            _reemplazar.TextoGeneral("DireccionBU4", Unidad.Direccion, docof, bold: 1);

            if (Oferta.IdBU == (int)BUEnum.HSA)
            {
                _reemplazar.TextoGeneral("BU", "South America", docof, bold: 1);
                _reemplazar.TextoGeneral("Unidad", "Howden South America", docof, bold: 1);
            }
            else if (Oferta.IdBU == (int)BUEnum.HCHL)
            {
                _reemplazar.TextoGeneral("BU", "Chile", docof, bold: 1);
                _reemplazar.TextoGeneral("Unidad", "Howden Chile S.p.A.", docof, bold: 1);
            }
            else if (Oferta.IdBU == (int)BUEnum.HPU)
            {
                _reemplazar.TextoGeneral("BU", "Perú ", docof, bold: 1);
                _reemplazar.TextoGeneral("Unidad", "Howden Perú S.R.L.", docof, bold: 1);
            }
            else { _reemplazar.TextoGeneral("BU", "", docof); }
        }
    }
}
