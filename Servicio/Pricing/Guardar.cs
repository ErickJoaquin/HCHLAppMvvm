﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Data;
using Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace Servicios.Pricing
{
    public class Guardar
    {
        public static void excelPDF(Oferta Oferta, Excel.Workbook Prcg, bool Consolidando)
        {
            List<(int, string)> carpetas = new List<(int, string)>()
            { (Oferta.IdBU, CarpetasEnum.comercialPricing.ToString()), (Oferta.IdBU, CarpetasEnum.comercialPricing.ToString()) };
            RepositorioCarpetas repPasta = new RepositorioCarpetas();
            List<string> rutas = repPasta.GetPathsAsync(carpetas).Result;
            string rutapricing = rutas[0];
            string rutapricingsr = rutas[1];

            if (String.IsNullOrEmpty(Oferta.NCRM.ToString()) || String.IsNullOrEmpty(Oferta.Rev.ToString())) 
            { 
                MessageBox.Show($"No se puedo guardar el pricing en la carpeta {rutapricing}, " +
                    $"debido a un problema en la generacioón del nombre de esta"); 
                return; 
            }
            else
            {
                rutapricing += $"R_{Oferta.NCRM}-R{Oferta.Rev}";
                if (Consolidando == true) { rutapricing += "_Consolidado"; }
                rutapricingsr += $"R_{Oferta.NCRM}";
            }

            Excel.Worksheet HojaPricing = default(Excel.Worksheet);
            HojaPricing = Prcg.Worksheets["Pricing"];

            object fileFormat = Excel.XlFileFormat.xlOpenXMLWorkbookMacroEnabled;
            Prcg.SaveAs(rutapricing + ".xlsm", fileFormat);
            HojaPricing.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, rutapricing + ".pdf");
        }
    }
}
