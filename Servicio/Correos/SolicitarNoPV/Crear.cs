using System.Collections.Generic;
using System.Linq;
using Servicios.Utilidades;
using Model;
using Outlook = Microsoft.Office.Interop.Outlook;
using Servicios.Hedge.Utilidades;
using Data.Interfaces;

namespace Servicios.Correos.SolicitarNoPV
{
    public class Crear
    {
        private readonly Aplica _hedge;
        private readonly InformacionCliente _infoCliente;
        private readonly IRepositorioBase<Usuario> _repUser;

        public List<int> _users;
        public object selectedObject;
        public Outlook.MailItem mailSelected;
        public Outlook.MailItem mailReply;
        public Microsoft.Office.Interop.Outlook.Application app;

        public Crear(Aplica hedge, InformacionCliente infoCliente, IRepositorioBase<Usuario> repUser)
        {
            this._hedge = hedge;
            this._infoCliente = infoCliente;
            this._repUser = repUser;

            _users = new List<int>();
            selectedObject = new object();
            mailSelected = new Outlook.MailItem();
            mailReply = new Outlook.MailItem();
            app = new Microsoft.Office.Interop.Outlook.Application();
        }

        public void Nuevo(Oferta Oferta, Pago Pago, OfertaClientes ofertaClientes, OfertaValores ofValores, OfertaMonedas Moneda, OC OC, Mercado Mercado)
        {
            (bool aplicaHedge, int HedgeNum) = _hedge.Evaluar(Oferta, Pago, ofValores, Moneda);
            string HedgeStg = (!aplicaHedge) ? "No" : "Si";

            Cliente Cliente = _infoCliente.Obtener(ofertaClientes);

            string body = "<HTML><BODY><FONT face=Arial color=#1F497D size=2>Samanta, <br/> <br/>";
            body += $"Por favor, enviar número de CA para la Orden de Compra {OC.Nombre} de {Cliente.Nombre} en anexo, recibida el {OC.FechaRecepcion.ToString("dd-MM-yyy")}. <br/> <br/>";
            body += "Verificar análisis de crédito para venta." + " <br/> <br/>";
            body += $"&nbsp;&nbsp;&nbsp;&nbsp;    Oferta - <b> {Oferta.NCRM}-R{Oferta.Rev} </b> <br/>";
            body += $"&nbsp;&nbsp;&nbsp;&nbsp;    Aplica Hedge? <b>{HedgeStg}</b> <br/><br/><br/>";
            body += "Saludos a todos, ";
            body += "</ FONT ></ BODY ></ HTML >";

            int[] intTraer = { Mercado.IdKAM, Mercado.IdKA};
            _users.AddRange(intTraer);
            List<Usuario> ListaUsuarios = _repUser.GetMultiIdAsync(_users).Result;

            selectedObject = app.ActiveExplorer().Selection[1];
            mailSelected = selectedObject as Outlook.MailItem;
            if (mailSelected == null) { mailReply = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem); }
            else { mailReply = mailSelected.Forward(); }

            mailReply.To = "sandra.silva@howden.com; samanta.ferreira@howden.com;";
            mailReply.CC = "marcos.pinto@howden.com; thais.trevine@howden.com; lisette.silva@howden.com; ";
            if (Mercado.IdKAM > 0) { mailReply.CC += "; " + ListaUsuarios.Where(n => n.Id == Mercado.IdKAM).ElementAt(0).Mail + "; "; }
            if (Mercado.IdKA > 0) { mailReply.CC += "; " + ListaUsuarios.Where(n => n.Id == Mercado.IdKA).ElementAt(0).Mail + "; "; }
            if (Oferta.IdBU == (int)BUEnum.HSA) { return; }
            else if (Oferta.IdBU == (int)BUEnum.HCHL) { mailReply.Subject = $"Solicitud de CA para OC {OC.Nombre} - Oferta {Oferta.NCRM}-R{Oferta.Rev}"; }
            else if (Oferta.IdBU == (int)BUEnum.HPU) { mailReply.Subject = $"Solicitud de PA para OC {OC.Nombre} - Oferta {Oferta.NCRM}-R{Oferta.Rev}"; }

            mailReply.HTMLBody = body + mailReply.HTMLBody + mailSelected.HTMLBody;

            mailReply.Display();
        }
    }
}
