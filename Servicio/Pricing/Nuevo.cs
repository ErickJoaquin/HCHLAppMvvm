using System;
using Model;
using Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using Servicios.Utilidades;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Pricing
{
    public class Nuevo
    {
        public static void NuevoDocumento(Oferta Oferta, OfertaClientes ofClientes, OfertaValores ofValores, Mercado Mercado, OfertaMonedas Monedas,
            bool Consolidando, bool incluyeRep, bool comoItem, bool prorratearPackaging, bool prorratearDespacho)
        {
            try
            {
                Excel.Worksheet HojaCostos = default(Excel.Worksheet);
                Excel.Worksheet HojaPricing = default(Excel.Worksheet);
                Excel.Worksheet HojaPersonal = default(Excel.Worksheet);
                Excel.Worksheet HojaOferta = default(Excel.Worksheet);
                Excel.Worksheet HojaMonedas = default(Excel.Worksheet);

                RepositorioCarpetas repCarpetas = new RepositorioCarpetas();
                string rutaprctemplate = repCarpetas.GetPathAsync((int)BUEnum.HCHL, CarpetasEnum.templates.ToString()).Result;

                Excel.Application ExcDoc = new Excel.Application();
                Excel.Workbook Prcg = ExcDoc.Workbooks.Open(rutaprctemplate);

                HojaCostos = Prcg.Worksheets["Costos"];
                HojaPricing = Prcg.Worksheets["Pricing"];
                HojaPersonal = Prcg.Worksheets["Personal"];
                HojaOferta = Prcg.Worksheets["Oferta"];
                HojaMonedas = Prcg.Worksheets["Tasas & NM"];

                var infoGral = new InfoGeneral();
                var infoItems = new InfoItems();
                var infoVals= new InfoValores();
                var infoCons = new InfoConsolidacion();

                RepositorioItem repItem = new RepositorioItem();
                List<Item> itemsOrdenados = repItem.GetByOffer(Oferta.Id).OrderBy(x => x.TipoItem).ThenBy(x => x.NSP).ToList();

                infoGral.Agregar(HojaPricing, HojaPersonal, Oferta, ofClientes, Mercado, incluyeRep, Consolidando);
                infoItems.Agregar(HojaCostos, Oferta, ofValores, itemsOrdenados, comoItem, prorratearPackaging, prorratearDespacho);
                infoVals.Agregar(HojaCostos, HojaPricing, HojaMonedas, Oferta, ofValores, Monedas, itemsOrdenados);
                infoCons.Agregar(HojaPricing, Oferta, Monedas);

                ExcDoc.Visible = true;
                HojaPricing.Visible = Excel.XlSheetVisibility.xlSheetVisible;

                ExcDoc.GetType().InvokeMember("Run", System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod, null, ExcDoc, new Object[] 
                { "RECALCULAR" });
   
                Guardar.excelPDF(Oferta, Prcg, Consolidando);              
                MoverRevisiones.trasladarAntiguas(Oferta, false);
            }
            catch (Exception ex) { MessageBox.Show("No se pudo crear el pricing, comuniquese con el administrador. Error: " + ex); }
        }
    }
}
