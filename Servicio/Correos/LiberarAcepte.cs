using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Data;
using Model;
using Outlook = Microsoft.Office.Interop.Outlook;
using Servicios.Utilidades;
using Servicios.Hedge;

namespace Servicios.Correos
{
    public class LiberarAcepte
    {
        public void Crear(Oferta Oferta, Mercado Mercado, OC OC, OfertaValores ofValores, OfertaMonedas Monedas)
        {
            if (Oferta == null) { 
                MessageBox.Show("Se debe seleccionar un ítem para continuar con esta acción. Si continúa con problemas, por favor dirigase al administrador"); 
                return; 
            }

            RepositorioBase<Pago> _repPago = new RepositorioBase<Pago>();
            Pago Pago = _repPago.GetByIdAsync(Oferta.IdTipoPago).Result;

            string body = Cuerpo(Oferta, OC, Pago, ofValores, Monedas);
            object selectedObject = null;
            Outlook.MailItem mailSelected = null;
            Outlook.MailItem mailReply = null;
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();

            selectedObject = app.ActiveExplorer().Selection[1];
            mailSelected = selectedObject as Outlook.MailItem;
            if (mailSelected == null) { mailReply = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem); }
            else { mailReply = mailSelected.Forward(); }

            var infoCliente = new InformacionCliente();
            Cliente Cliente = infoCliente.obtener(Oferta);
            string cliente = Cliente.Nombre;

            mailReply.To = "samanta.ferreira@howden.com; sandra.silva@howden.com"; //Pendiente, hablar con Lino
            mailReply.CC = "marcos.pinto@howden.com; lisette.silva@howden.com; thais.trevine@howden.com; ";

            List<int> _usuariosATraer = new List<int>() { Mercado.IdKA, Mercado.IdKAM };
            RepositorioBase<Usuario> repUser = new RepositorioBase<Usuario>();
            List<Usuario> ListaUsuarios = repUser.GetMultiIdAsync(_usuariosATraer).Result;

            if (Mercado.IdKAM != 0) { mailReply.CC += "; " + ListaUsuarios.Where(n => n.Id == Mercado.IdKAM).ElementAt(0).Mail + "; "; }
            if (Mercado.IdKA != 0) { mailReply.CC += "; " + ListaUsuarios.Where(n => n.Id == Mercado.IdKA).ElementAt(0).Mail + "; "; }

            mailReply.Subject = $"Consolidación {Oferta.NPV} - {cliente} - {Oferta.NCRM}";

            mailReply.HTMLBody = body + mailReply.HTMLBody + mailSelected.HTMLBody;

            mailReply.Display();

            AbrirDocumentosParaComparar(Oferta, OC);
        }

        private string Cuerpo(Oferta Oferta, OC OC, Pago Pago, OfertaValores ofValores, OfertaMonedas Monedas)
        {
            var _hedge = new Hedge.Aplica();
            (bool aplicaHedge, int HedgeNum) = _hedge.Evaluar(Oferta, Pago, ofValores, Monedas);

            var Curr = (MonedasEnum)Oferta.IdMoneda;
            var Entrega = (TipoEntregaEnum)Oferta.IdTipoEntrega;

            string body = "<HTML><BODY><FONT face=Arial color=#1F497D size=2><b>Samanta</b>,  <br/> Espero que estés bien <br/> <br/>";
            body += "Sigue: <br/>";
            body += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ✓ &nbsp;&nbsp;  Liberar Acepte del pedido <b>" + Oferta.NPV + "</b> <br/>"; //+ NPV +
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

        private void AbrirDocumentosParaComparar(Oferta Oferta, OC OC)
        {
            List<(int, string)> _pastasATraer = new List<(int, string)>() { (Oferta.IdBU, "comercialOferta"), (Oferta.IdBU, "ventas") };
            RepositorioCarpetas _repPasta = new RepositorioCarpetas();
            List<string> rutas = _repPasta.GetPathsAsync(_pastasATraer).Result;
            string rutaoferta = rutas[0];
            string rutaoc = rutas[1];

            rutaoferta += $"P_{Oferta.NCRM}-R{Oferta.Rev}_Consolidada.pdf";
            rutaoc += $@"\COMERCIAL\Contrato o Pedido de Compras del Cliente\{OC.Nombre}.pdf";

            try
            {
                Process.Start(rutaoferta);
            }
            catch (Exception g)
            {
                MessageBox.Show($"Al parecer, no se encontró ningún documento con el nombre: {Oferta.NCRM}-R en la siguiente ruta: {rutaoferta}. " +
                    $"Hablar con el administrador, error: " + g);
            }

            try
            {
                Process.Start(rutaoc);
            }
            catch (Exception f)
            {
                MessageBox.Show($"Al parecer, no se encontró ningún documento con el nombre: {OC.Nombre} en la siguiente ruta: {rutaoc}. " +
                    "Hablar con el administrador, error: " + f);
            }
        }

    }
}
