using System.Collections.Generic;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Model;
using Data;

namespace Servicios.Pricing
{
    public class InfoValores
    {
        public void Agregar(Excel.Worksheet HojaCostos, Excel.Worksheet HojaPricing, Excel.Worksheet HojaMonedas, Oferta Oferta, 
            OfertaValores ofValores, OfertaMonedas Monedas, List<Item> itemsOrdenados)
        {
            RepositorioBase<BU> _repBU = new RepositorioBase<BU>();
            BU Proveedor = _repBU.GetByIdAsync(Oferta.IdProveedor).Result;

            double CostoTotalCD = itemsOrdenados.Where(x => x.TipoItem == TipoItemEnum.SP.ToString()).
                Select(x => x.VentaUnitaria * x.Qty).Sum() * ofValores.DescuentoProveedor;

            double CostoServicioSD = itemsOrdenados.Where(x => x.TipoItem == TipoItemEnum.SV.ToString()).Select(x => x.VentaUnitaria * x.Qty).Sum();

            ///Valores en Desglose de precios
            HojaPricing.Range["E24"].Value = CostoTotalCD + ofValores.Packaging;
            HojaPricing.Range["E27"].Value = CostoServicioSD;
            HojaPricing.Range["E28"].Value = Proveedor.ValorDocumento;
            HojaPricing.Range["D31"].Value = (ofValores.Fin / 100);
            HojaPricing.Range["D32"].Value = (ofValores.Ing / 100);
            HojaPricing.Range["B29"].Value = "Aduana";
            HojaPricing.Range["B30"].Value = "Transporte";
            HojaPricing.Range["E29"].Value = ofValores.Aduana;
            HojaPricing.Range["E30"].Value = ofValores.Transporte;

            //Tasas
            HojaMonedas.Range["H4"].Value = Monedas.BRL;
            HojaMonedas.Range["H5"].Value = Monedas.CLP;
            HojaMonedas.Range["H6"].Value = Monedas.EUR;
            HojaMonedas.Range["H7"].Value = Monedas.GBP;

            ///Cargar Valores finales
            HojaPricing.Range["P17"].Value = Oferta.VLiquida;
            HojaPricing.Range["E41"].Value = ofValores.BAdelanto + ofValores.BCalidadGarantia + ofValores.BFielCumplimiento;
            HojaPricing.Range["M45"].Value = ofValores.MN / 100;
            HojaPricing.Range["D37"].Value = ofValores.RAdicional / 100;
            HojaCostos.Range["M5"].Value = (1 - ofValores.DescuentoProveedor / 100);
        }
    }
}
