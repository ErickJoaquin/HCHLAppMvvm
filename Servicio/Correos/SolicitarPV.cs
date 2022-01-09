using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Utilidades;
using Model;
using Data;
using Outlook = Microsoft.Office.Interop.Outlook;
using Servicios.Hedge;

namespace Servicios.Correos
{
    public class SolicitarPV
    {
        public void crear(Oferta Oferta, Pago Pago, OfertaValores ofValores, OfertaMonedas Moneda, OC OC, Mercado Mercado)
        {
            var _hedge = new Hedge.Aplica();
            (bool aplicaHedge, int HedgeNum) = _hedge.Evaluar(Oferta, Pago, ofValores, Moneda);
            string HedgeStg = (!aplicaHedge) ? "No" : "Si";

            var infoCliente = new InformacionCliente();
            Cliente Cliente = infoCliente.obtener(Oferta);

            string body = "<HTML><BODY><FONT face=Arial color=#1F497D size=2>Samanta, <br/> <br/>";
            body += $"Por favor, enviar número de CA para la Orden de Compra {OC.Nombre} de {Cliente.Nombre} en anexo, recibida el {OC.FechaRecepcion.ToString("dd-MM-yyy")}. <br/> <br/>";
            body += "Verificar análisis de crédito para venta." + " <br/> <br/>";
            body += $"&nbsp;&nbsp;&nbsp;&nbsp;    Oferta - <b> {Oferta.NCRM}-R{Oferta.Rev} </b> <br/>";
            body += $"&nbsp;&nbsp;&nbsp;&nbsp;    Aplica Hedge? <b>{HedgeStg}</b> <br/><br/><br/>";
            body += "Saludos a todos, ";
            body += "</ FONT ></ BODY ></ HTML >";

            List<int> _users = new List<int>() { Mercado.IdKAM, Mercado.IdKA};
            RepositorioBase<Usuario> _repUser = new RepositorioBase<Usuario>();
            List<Usuario> ListaUsuarios = _repUser.GetMultiIdAsync(_users).Result;

            object selectedObject = null;
            Outlook.MailItem mailSelected = null;
            Outlook.MailItem mailReply = null;
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();

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

            //mail.Attachments.Add(@"c:\sales reports\fy06q4.xlsx", Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing); //Ver Drag&Drop option

            mailReply.HTMLBody = body + mailReply.HTMLBody + mailSelected.HTMLBody;

            mailReply.Display();
        }
    }
}
