using System;
using Model;
using System.Windows.Forms;
using Servicios.Hedge.Utilidades;

namespace Servicios.Hedge
{
    public class Crear
    {
        private readonly Nuevo _nuevo;
        private readonly Aplica _aplica;
        public Crear(Nuevo nuevo, Aplica aplica)
        {
            this._nuevo = nuevo;
            this._aplica = aplica;
        }

        public void RevisarCuantos(Oferta Oferta, OC OC, Pago Pago, OfertaClientes ofClientes, OfertaValores ofValores, OfertaMonedas Moneda)
        {
            if (Oferta == null) { MessageBox.Show("Se debe seleccionar un ítem para continuar con esta acción. " +
                "Si continúa con problemas, por favor dirigase al administrador"); 
                return; }

            (bool aplicaHedge, int HedgeNum) = _aplica.Evaluar(Oferta, Pago, ofValores, Moneda);

            if (aplicaHedge)
            {
                double HedgeMonto1 = Convert.ToDouble(Oferta.VentaTotal) * Convert.ToDouble(Pago.Pago1) / 100;
                double HedgeMonto2 = Convert.ToDouble(Oferta.VentaTotal) * Convert.ToDouble(Pago.Pago2) / 100;
                var Curr = (MonedasEnum)Oferta.IdMoneda;
                var HedgeCurr = Curr.ToString();
                double HedgeEUR = Moneda.EUR;

                if (HedgeNum == 1) { _nuevo.Crear(Oferta, ofClientes, OC, HedgeMonto1, 1, HedgeCurr); }
                if (HedgeNum == 2) { _nuevo.Crear(Oferta, ofClientes, OC, HedgeMonto2, 2, HedgeCurr); }
                if (HedgeNum == 3)
                {
                    _nuevo.Crear(Oferta, ofClientes, OC, HedgeMonto1, 1, HedgeCurr);
                    _nuevo.Crear(Oferta, ofClientes, OC, HedgeMonto2, 2, HedgeCurr);
                }
            }
        }
    }
}
