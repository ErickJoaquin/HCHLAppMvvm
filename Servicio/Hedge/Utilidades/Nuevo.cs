using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using Model;
using Data;

namespace Servicios.Hedge.Utilidades
{
    public class Nuevo
    {
        private readonly InfoGeneral _infoGral;
        private readonly Guardar _guardar;
        private readonly RepositorioCarpetas _repPasta;
        public List<(int, string)> carpetas;
        public Excel.Application ExcDoc;
        public List<string> rutas;
        public Nuevo(RepositorioCarpetas repPasta, InfoGeneral infoGral, Guardar guardar)
        {
            this._repPasta = repPasta;
            this._infoGral = infoGral;
            this._guardar = guardar;

            carpetas = new List<(int, string)>();
            ExcDoc = new Excel.Application();
            rutas = new List<string>();
        }

        public void Crear(Oferta Oferta, OfertaClientes ofClientes, OC OC, double monto, int n, string curr)
        {
            Excel.Worksheet HojaHedge = default(Excel.Worksheet);

            (int, string)[] toGet = { (Oferta.IdBU, CarpetasEnum.templates.ToString()), (Oferta.IdBU, CarpetasEnum.ventas.ToString()) };
            carpetas.AddRange(toGet);
            rutas = _repPasta.GetPathsAsync(carpetas).Result;
            string rutahdgetemplate = rutas[0];
            Excel.Workbook Hedge = ExcDoc.Workbooks.Open(rutahdgetemplate);

            HojaHedge = Hedge.Worksheets["Documentation at Inception"];

            ExcDoc.Visible = true;
            HojaHedge.Visible = Excel.XlSheetVisibility.xlSheetVisible;

            _infoGral.Agregar(HojaHedge, Oferta, ofClientes, OC, monto, curr);

            _guardar.ExcelPFF(Hedge, Oferta, rutas[1], n);
        }
    }
}
