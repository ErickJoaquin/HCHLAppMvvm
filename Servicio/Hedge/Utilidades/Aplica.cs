using System;
using Model;

namespace Servicios.Hedge.Utilidades
{
    public class Aplica
    {
        public (bool, int) Evaluar(Oferta Oferta, Pago Pago, OfertaValores ofValores, OfertaMonedas Moneda)
        {
            bool aplicaHedge = false;
            int HedgeNum = 0;

            double HedgeMonto1 = Convert.ToDouble(Oferta.VLiquida) * Convert.ToDouble(Pago.Pago1) / 100;
            double HedgeMonto2 = Convert.ToDouble(Oferta.VLiquida) * Convert.ToDouble(Pago.Pago2) / 100;
            var _curr = (MonedasEnum)Oferta.IdMoneda;
            string HedgeCurr = _curr.ToString();
            double HedgeEUR = Moneda.EUR;


            if ((HedgeCurr == MonedasEnum.USD.ToString()) && (HedgeMonto1 > 75000 || HedgeMonto2 > 75000)) //&& (pago1 != hitoa) && (pago2 != hitoa) && (pago1 != hitob) && (pago2 != hitob)
            {
                aplicaHedge = true;
                if (HedgeMonto1 > 75000 && HedgeMonto2 < 75000) { HedgeNum = 1; }
                if (HedgeMonto1 < 75000 && HedgeMonto2 > 75000) { HedgeNum = 2; }
                if (HedgeMonto1 > 75000 && HedgeMonto2 > 75000) { HedgeNum = 3; }
            }
            else if (HedgeCurr == MonedasEnum.EUR.ToString() && (HedgeMonto1 / HedgeEUR > 75000 || HedgeMonto2 / HedgeEUR > 75000)) //&& (pago1 != hitoa) && (pago2 != hitoa) && (pago1 != hitob) && (pago2 != hitob)
            {
                aplicaHedge = true;
                if (HedgeMonto1 / HedgeEUR > 75000 && HedgeMonto2 / HedgeEUR < 75000) { HedgeNum = 1; }
                if (HedgeMonto1 / HedgeEUR < 75000 && HedgeMonto2 / HedgeEUR > 75000) { HedgeNum = 2; }
                if (HedgeMonto1 / HedgeEUR > 75000 && HedgeMonto2 / HedgeEUR > 75000) { HedgeNum = 3; }
            }

            return (aplicaHedge, HedgeNum);
        }
    }
}
