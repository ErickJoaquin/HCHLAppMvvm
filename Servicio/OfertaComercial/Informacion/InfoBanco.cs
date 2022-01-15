using System;
using Model;
using Word = Microsoft.Office.Interop.Word;
using Servicios.OfertaComercial.Utilidades;

namespace Servicios.OfertaComercial.Informacion
{
    public class InfoBanco
    {
        private readonly ReemplazarEnWord _reemplazar;
        public InfoBanco(ReemplazarEnWord reemplazar)
        {
            this._reemplazar = reemplazar;
        }
        public void Agregar(Oferta Oferta, BU Unidad, Word.Document docof)
        {
            var curr = (MonedasEnum)Oferta.IdMoneda;
            string Curr = curr.ToString();

            if (!String.IsNullOrEmpty(Curr))
            {
                _reemplazar.TextoGeneral("Curr", Curr, docof, bold: 1);
                _reemplazar.TextoGeneral("Curr2", Curr, docof, bold: 1);
                _reemplazar.TextoGeneral("Curr3", Curr, docof, bold: 1);

                if (Oferta.IdBU == (int)BUEnum.HCHL)
                {
                    _reemplazar.TextoGeneral("TipoIDTrib", "RUT: ", docof);
                    _reemplazar.TextoGeneral("IDTrib", Unidad.IdTributario, docof, bold: 1);
                    _reemplazar.TextoGeneral("Banco", "HSBC Bank Chile", docof, bold: 1);

                    if ((int)MonedasEnum.CLP == Oferta.IdMoneda)
                    {
                        _reemplazar.TextoGeneral("Moneda", "Peso Chileno - CLP", docof);
                        for (int i = 0; i < 19; i++) { docof.Tables[6].Rows[5].Delete(); }
                    }
                    else if ((int)MonedasEnum.EUR == Oferta.IdMoneda)
                    {
                        _reemplazar.TextoGeneral("Moneda", "Euro - EUR", docof);
                        for (int i = 0; i < 4; i++) { docof.Tables[6].Rows[1].Delete(); }
                        for (int i = 0; i < 12; i++) { docof.Tables[6].Rows[8].Delete(); }
                    }
                    else if ((int)MonedasEnum.USD == Oferta.IdMoneda || (int)MonedasEnum.GBP == Oferta.IdMoneda)
                    {
                        if (Oferta.Idioma == "Esp"){
                            _reemplazar.TextoGeneral("Moneda", "Dólar Americano - USD", docof);
                        }                            
                        else { _reemplazar.TextoGeneral("Moneda", "American Dollar - USD", docof); }

                        for (int i = 0; i < 11; i++) { docof.Tables[6].Rows[1].Delete(); }
                        for (int i = 0; i < 4; i++) { docof.Tables[6].Rows[9].Delete(); }
                    }
                }
                else if (Oferta.IdBU == (int)BUEnum.HPU)
                {
                    _reemplazar.TextoGeneral("TipoIDTrib", "RUC: ", docof);
                    _reemplazar.TextoGeneral("IDTrib", Unidad.IdTributario, docof, bold: 1);
                    _reemplazar.TextoGeneral("Banco", "Santander", docof, bold: 1);

                    if ((int)MonedasEnum.PEN == Oferta.IdMoneda)
                    {
                        _reemplazar.TextoGeneral("Moneda", "Nuevo Sol peruano - SOL", docof);
                        for (int i = 0; i < 20; i++) { docof.Tables[6].Rows[1].Delete(); }
                        docof.Tables[6].Rows[4].Delete();
                    }
                    else 
                    {
                        if (Oferta.Idioma == "Esp")
                        {
                            _reemplazar.TextoGeneral("Moneda", "Dólar Americano - USD", docof);
                        }
                        else { _reemplazar.TextoGeneral("Moneda", "American Dollar - USD", docof); }
                        for (int i = 0; i < 20; i++) { docof.Tables[6].Rows[1].Delete(); }
                        docof.Tables[6].Rows[3].Delete();
                    }
                }
            }
        }
    }
}
