using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using Model;
using Data;
using System.Windows.Forms;

namespace Servicios.Hedge
{
    public class Nuevo
    {
        public void crear(Oferta Oferta, OC OC, double monto, int n, string curr)
        {
            Excel.Worksheet HojaHedge = default(Excel.Worksheet);

            List<(int, string)> carpetas = new List<(int, string)>()
            { (Oferta.IdBU, CarpetasEnum.templates.ToString()), (Oferta.IdBU, CarpetasEnum.ventas.ToString()) };

            RepositorioCarpetas _repPasta = new RepositorioCarpetas();
            List<string> rutas = _repPasta.GetPathsAsync(carpetas).Result;
            string rutahdgetemplate = rutas[0];

            Excel.Application ExcDoc = new Excel.Application();
            Excel.Workbook Hedge = ExcDoc.Workbooks.Open(rutahdgetemplate);

            HojaHedge = Hedge.Worksheets["Documentation at Inception"];

            ExcDoc.Visible = true;
            HojaHedge.Visible = Excel.XlSheetVisibility.xlSheetVisible;

            var infoGral = new InfoGeneral();
            infoGral.agregar(HojaHedge, Oferta, OC, monto, curr);

            Guardar.excelPFF(Hedge, Oferta, rutas[1], n);
        }
    }
}
