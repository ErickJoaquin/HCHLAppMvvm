using Excel = Microsoft.Office.Interop.Excel;
using Model;
using Servicios.Utilidades;

namespace Servicios.Pricing.Informaciones
{
    public class InfoConsolidacion
    {
        private readonly Moneda _cambios;
        public InfoConsolidacion(Moneda cambios)
        {
            this._cambios = cambios;
        }

        public void Agregar(Excel.Worksheet HojaPricing, Oferta Oferta, OfertaMonedas Monedas)
        {
            if ((Oferta.IdBU == (int)BUEnum.HCHL && Oferta.IdMoneda != (int)MonedasEnum.CLP) || 
                (Oferta.IdBU == (int)BUEnum.HPU && Oferta.IdMoneda != (int)MonedasEnum.PEN))
            {
                double cambio = (Oferta.IdMoneda != (int)MonedasEnum.GBP) ? Monedas.GBP : (Oferta.IdMoneda != (int)MonedasEnum.BRL) ? 
                    Monedas.BRL : (Oferta.IdMoneda != (int)MonedasEnum.EUR) ? Monedas.EUR : (Oferta.IdMoneda != (int)MonedasEnum.CLP) ? 
                    Monedas.CLP : (Oferta.IdMoneda != (int)MonedasEnum.PEN) ? Monedas.SOL : 1;

                var Curr = (MonedasEnum)Oferta.IdMoneda;

                double vLiquidaConsolidada = (Oferta.IdMoneda != (int)MonedasEnum.CLP) ?
                    _cambios.Convert(Oferta.VLiquida, Curr.ToString(), MonedasEnum.CLP.ToString(), cambio, Monedas.CLP) :
                    (Oferta.IdBU == (int)BUEnum.HPU) ?
                    _cambios.Convert(Oferta.VLiquida, Curr.ToString(), MonedasEnum.PEN.ToString(), cambio, Monedas.SOL) : 0;

                HojaPricing.Range["P14"].Value = (Oferta.IdMoneda != (int)MonedasEnum.CLP) ? MonedasEnum.CLP.ToString() : 
                    (Oferta.IdBU == (int)BUEnum.HPU) ? MonedasEnum.PEN.ToString() : "";
                HojaPricing.Range["Q14"].Value = (vLiquidaConsolidada != 0) ? vLiquidaConsolidada : 0;

                HojaPricing.Range["O8"].Value = (vLiquidaConsolidada != 0) ? (vLiquidaConsolidada / Oferta.VLiquida) : 0;
                HojaPricing.Range["Q8"].Value = (Oferta.IdMoneda != (int)MonedasEnum.CLP) ? 
                    $"{MonedasEnum.CLP.ToString()} = 1 {Curr.ToString()}" : 
                    (Oferta.IdBU == (int)BUEnum.HPU) ? 
                    $"{MonedasEnum.PEN.ToString()} = 1 {Curr.ToString()}" : "";
            }
            else { HojaPricing.Range["K14"].Value = ""; }
        }
    }
}
