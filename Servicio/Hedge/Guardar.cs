using Model;
using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Servicios.Hedge
{
    public class Guardar
    {
        public static void excelPFF(Excel.Workbook Hedge, Oferta Oferta, string rutacarpeta, int n)
        {
            if (Oferta.IdBU == (int)BUEnum.HCHL || Oferta.IdBU == (int)BUEnum.HPU)
            {
                rutacarpeta += "\\FINANCIERO\\Hedge\\Hedge_Contract_";
                if (Oferta.NPV == "")
                {
                    MessageBox.Show($"No se puede guardar el pricing en la carpeta {rutacarpeta}, debido a un problema " +
                                    $"en la generación del nombre de esta");
                    return;
                }
                else { rutacarpeta += Oferta.NPV; }
            }
            else if (Oferta.IdBU == (int)BUEnum.HSA)
            {
                return;
            }

            if (n == 2) { rutacarpeta += "-2"; }

            object fileFormat = Excel.XlFileFormat.xlOpenXMLWorkbookMacroEnabled;

            try
            {
                Hedge.SaveAs(rutacarpeta + ".xlsm", fileFormat);

                MessageBox.Show($"Documento guardado como: {rutacarpeta}. Favor revisar las informaciones ingresadas.");
            }
            catch (Exception e)
            {
                MessageBox.Show($"El documento no se pudo guardar en la siguiente dirección: {rutacarpeta}. " +
                    $"Inténtelo de nuevo o comuniquese con el administrador. Error: " + e);
            }
        }
    }
}
