using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model;
using Outlook = Microsoft.Office.Interop.Outlook;
using Servicios.Utilidades;
using Servicios.Correos.LiberacionAcepte.Utilidades;
using Data.Interfaces;

namespace Servicios.Correos.LiberacionAcepte
{
    public class Crear
    {
        private readonly Cuerpo _cuerpo;
        private readonly DocumentosAComparar _docToBuy;
        private readonly IRepositorioBase<Pago> _repPago;
        private readonly IRepositorioBase<Usuario> _repUser;
        private readonly InformacionCliente _infoCliente;

        public object selectedObject;
        public Outlook.MailItem mailSelected;
        public Outlook.MailItem mailReply;
        public Microsoft.Office.Interop.Outlook.Application app;
        public Pago Pago;
        public Cliente Cliente;
        public List<int> _usuariosATraer;
        public List<Usuario> ListaUsuarios;

        public Crear(Cuerpo cuerpo, DocumentosAComparar docToBuy, IRepositorioBase<Pago> repPago, IRepositorioBase<Usuario> repUser, InformacionCliente infoCliente)
        {
            this._cuerpo = cuerpo;
            this._docToBuy = docToBuy;
            this._repPago = repPago;
            this._repUser = repUser;
            this._infoCliente = infoCliente;

            selectedObject = new object();
            mailSelected = new Outlook.MailItem();
            mailReply = new Outlook.MailItem();
            app = new Microsoft.Office.Interop.Outlook.Application();

            Pago = new Pago();
            Cliente = new Cliente();
            _usuariosATraer = new List<int>();
            ListaUsuarios = new List<Usuario>();
        }

        public void Nuevo(Oferta Oferta, OfertaClientes ofClientes, Mercado Mercado, OC OC, OfertaValores ofValores, OfertaMonedas Monedas)
        {
            if (Oferta == null) { 
                MessageBox.Show("Se debe seleccionar un ítem para continuar con esta acción. Si continúa con problemas, por favor dirigase al administrador"); 
                return; 
            }

            Pago = _repPago.GetByIdAsync(Oferta.IdTipoPago).Result;

            string body = _cuerpo.Agregar(Oferta, OC, Pago, ofValores, Monedas);

            selectedObject = app.ActiveExplorer().Selection[1];
            mailSelected = selectedObject as Outlook.MailItem;
            if (mailSelected == null) { mailReply = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem); }
            else { mailReply = mailSelected.Forward(); }

            Cliente = _infoCliente.Obtener(ofClientes);

            mailReply.To = "samanta.ferreira@howden.com; sandra.silva@howden.com"; //Pendiente, hablar con Lino
            mailReply.CC = "marcos.pinto@howden.com; lisette.silva@howden.com; thais.trevine@howden.com; ";

            int[] intTraer = { Mercado.IdKA, Mercado.IdKAM };
            _usuariosATraer.AddRange(intTraer);
            List<Usuario> ListaUsuarios = _repUser.GetMultiIdAsync(_usuariosATraer).Result;

            if (Mercado.IdKAM != 0) { mailReply.CC += $"; {ListaUsuarios.Where(n => n.Id == Mercado.IdKAM).ElementAt(0).Mail}; "; }
            if (Mercado.IdKA != 0) { mailReply.CC += $"; {ListaUsuarios.Where(n => n.Id == Mercado.IdKA).ElementAt(0).Mail}; "; }

            mailReply.Subject = $"Consolidación {Oferta.NPV} - {Cliente.Nombre} - {Oferta.NCRM}";

            mailReply.HTMLBody = body + mailReply.HTMLBody + mailSelected.HTMLBody;

            mailReply.Display();

            _docToBuy.Abrir(Oferta, OC);
        }
    }
}
