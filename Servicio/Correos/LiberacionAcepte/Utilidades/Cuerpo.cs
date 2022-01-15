using Model;
using Servicios.Hedge.Utilidades;

namespace Servicios.Correos.LiberacionAcepte.Utilidades
{
    public class Cuerpo
    {
        private readonly Aplica _hedge;
        public Cuerpo(Aplica hedge)
        {
            this._hedge = hedge;
        }

        public string Agregar(Oferta Oferta, OC OC, Pago Pago, OfertaValores ofValores, OfertaMonedas Monedas)
        {
            (bool aplicaHedge, int HedgeNum) = _hedge.Evaluar(Oferta, Pago, ofValores, Monedas);

            var Curr = (MonedasEnum)Oferta.IdMoneda;
            var Entrega = (TipoEntregaEnum)Oferta.IdTipoEntrega;

            string body = "<HTML><BODY><FONT face=Arial color=#1F497D size=2><b>Samanta</b>,  <br/> Espero que estés bien <br/> <br/>";
            body += "Sigue: <br/>";
            body += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ✓ &nbsp;&nbsp;  Liberar Acepte del pedido <b>" + Oferta.NPV + "</b> <br/>";
            body += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ✓ &nbsp;&nbsp;  Pricing - Aprobado <br/>";
            body += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ✓ &nbsp;&nbsp;  Propuesta consolidada en la carpeta de ventas <br/>";
            if (aplicaHedge) { body += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ✓ &nbsp;&nbsp;  Hedge creado y guardado en la carpeta de Financiero <br/><br/><br/>"; }
            else { body += "<br/><br/><br/>"; }
            body += "<b>Comentarios para el Acepte:</b> <br/>";
            body += "<span style='color: red'><b> &nbsp;&nbsp;&nbsp;&nbsp; - Monto y moneda: </b></span><br/>";
            body += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - OC:<br/>";
            body += $"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - Oferta: <b> {Curr.ToString()}: {Oferta.VentaTotal.ToString("C2")} </b><br/><br/>";
            body += "<span style='color: red'><b> &nbsp;&nbsp;&nbsp;&nbsp; - Medio de Pago:</b></span><br/>";
            body += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - OC:<br/>";
            body += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - Oferta: <b> " + Pago.Descripcion + " </b><br/><br/>";
            body += "<span style='color: red'><b> &nbsp;&nbsp;&nbsp;&nbsp; - Fecha de Entrega:</b></span><br/>";
            body += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - OC:<br/>";
            body += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - Oferta: <b> " + OC.FechaEntrega.AddDays(Oferta.PlazoEntrega) + " </b><br/><br/>";
            body += "<span style='color: red'><b> &nbsp;&nbsp;&nbsp;&nbsp; - Incoterms:</b></span><br/>";
            body += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - OC:<br/>";
            body += $"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - Oferta: <b> {Entrega.ToString()} - {Oferta.DireccionEntrega} </b><br/><br/>";
            body += "Saludos y gracias, ";
            body += "</ FONT ></ BODY ></ HTML >";

            return body;
        }
    }
}
