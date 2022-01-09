using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using Model;
using Data;
using System.Windows.Forms;

namespace Servicios.Hedge
{
    public class RevisarCuantos
    {
        public void revisarCuantos(Oferta Oferta, OC OC, Pago Pago, OfertaValores ofValores, OfertaMonedas Moneda)
        {
            if (Oferta == null) { MessageBox.Show("Se debe seleccionar un ítem para continuar con esta acción. " +
                "Si continúa con problemas, por favor dirigase al administrador"); 
                return; }

            var _hedge = new Aplica();
            (bool aplicaHedge, int HedgeNum) = _hedge.Evaluar(Oferta, Pago, ofValores, Moneda);

            double HedgeMonto1 = Convert.ToDouble(Oferta.VentaTotal) * Convert.ToDouble(Pago.Pago1) / 100;
            double HedgeMonto2 = Convert.ToDouble(Oferta.VentaTotal) * Convert.ToDouble(Pago.Pago2) / 100;
            var Curr = (MonedasEnum)Oferta.IdMoneda;
            var HedgeCurr = Curr.ToString();
            double HedgeEUR = Moneda.EUR;

            var nuevo = new Nuevo();

            if (aplicaHedge)
            {
                if (HedgeNum == 1) { nuevo.crear(Oferta, OC, HedgeMonto1, 1, HedgeCurr); }
                if (HedgeNum == 2) { nuevo.crear(Oferta, OC, HedgeMonto2, 2, HedgeCurr); }
                if (HedgeNum == 3)
                {
                    nuevo.crear(Oferta, OC, HedgeMonto1, 1, HedgeCurr);
                    nuevo.crear(Oferta, OC, HedgeMonto2, 2, HedgeCurr);
                }
            }
        }
    }
}
