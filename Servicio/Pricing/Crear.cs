using System;
using Model;
using Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using Servicios.Utilidades;
using System.Collections.Generic;
using System.Linq;
using Servicios.Pricing.Informaciones;
using Servicios.Pricing.Utilidades;

namespace Servicios.Pricing
{
    public class Crear
    {
        private readonly InfoGeneral _infoGral;
        private readonly InfoItems _infoItems;
        private readonly InfoValores _infoVals;
        private readonly InfoConsolidacion _infoCons;
        private readonly RepositorioCarpetas _repCarpetas;
        private readonly RepositorioItem _repItem;
        private readonly Guardar _guardar;
        private readonly MoverRevisiones _moverRevs;
        public Excel.Application ExcDoc;

        public Crear(InfoGeneral infoGral, InfoItems infoItems, InfoValores infoVals, InfoConsolidacion infoCons, RepositorioCarpetas repCarpetas, RepositorioItem repItem,
            Guardar guardar, MoverRevisiones moverRevs)
        {
            this._infoGral = infoGral;
            this._infoItems = infoItems;
            this._infoVals = infoVals;
            this._infoCons = infoCons;
            this._repCarpetas = repCarpetas;
            this._repItem = repItem;
            this._guardar = guardar;
            this._moverRevs = moverRevs;

            ExcDoc = new Excel.Application();
        }

        public void NuevoDocumento(Oferta Oferta, OfertaClientes ofClientes, OfertaValores ofValores, Mercado Mercado, OfertaMonedas Monedas,
            bool Consolidando, bool incluyeRep, bool comoItem, bool prorratearPackaging, bool prorratearDespacho)
        {
            try
            {
                Excel.Worksheet HojaCostos = default(Excel.Worksheet);
                Excel.Worksheet HojaPricing = default(Excel.Worksheet);
                Excel.Worksheet HojaPersonal = default(Excel.Worksheet);
                Excel.Worksheet HojaOferta = default(Excel.Worksheet);
                Excel.Worksheet HojaMonedas = default(Excel.Worksheet);

                string rutaprctemplate = _repCarpetas.GetPathAsync((int)BUEnum.HCHL, CarpetasEnum.templates.ToString()).Result;

                Excel.Workbook Prcg = ExcDoc.Workbooks.Open(rutaprctemplate);

                HojaCostos = Prcg.Worksheets["Costos"];
                HojaPricing = Prcg.Worksheets["Pricing"];
                HojaPersonal = Prcg.Worksheets["Personal"];
                HojaOferta = Prcg.Worksheets["Oferta"];
                HojaMonedas = Prcg.Worksheets["Tasas & NM"];

                List<Item> itemsOrdenados = _repItem.GetByOffer(Oferta.Id).OrderBy(x => x.TipoItem).ThenBy(x => x.NSP).ToList();

                _infoGral.Agregar(HojaPricing, HojaPersonal, Oferta, ofClientes, Mercado, incluyeRep, Consolidando);
                _infoItems.Agregar(HojaCostos, Oferta, ofValores, itemsOrdenados, comoItem, prorratearPackaging, prorratearDespacho);
                _infoVals.Agregar(HojaCostos, HojaPricing, HojaMonedas, Oferta, ofValores, Monedas, itemsOrdenados);
                _infoCons.Agregar(HojaPricing, Oferta, Monedas);

                ExcDoc.Visible = true;
                HojaPricing.Visible = Excel.XlSheetVisibility.xlSheetVisible;

                ExcDoc.GetType().InvokeMember("Run", System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod, null, ExcDoc, new Object[] 
                { "RECALCULAR" });
   
                _guardar.ExcelPDF(Oferta, Prcg, Consolidando);              
                _moverRevs.TrasladarAntiguas(Oferta, false);
            }
            catch (Exception ex) { MessageBox.Show("No se pudo crear el pricing, comuniquese con el administrador. Error: " + ex); }
        }
    }
}
