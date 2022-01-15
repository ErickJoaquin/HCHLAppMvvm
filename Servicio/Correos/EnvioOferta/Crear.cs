using System.Collections.Generic;
using Model;
using Data;
using Outlook = Microsoft.Office.Interop.Outlook;
using Servicios.Correos.EnvioOferta.Utilidades;
using Data.Interfaces;

namespace Servicios.Correos.EnvioOferta
{
    public class Crear
    {
        private readonly IRepositorioBase<Usuario> _repUser;
        private readonly IRepositorioBase<ContactoCliente> _repCcto;
        private readonly RepositorioContactos _repCtps;
        private readonly Cuerpo _cuerpo;
        private readonly DetallesCorreo _detalles;
        private readonly AdjuntarArchivos _adjuntar;

        public List<int> aObtener;
        public Outlook.Application app;
        public Outlook.MailItem mailSelected;
        public Outlook.MailItem mailReply;


        public Crear(IRepositorioBase<Usuario> repUser, IRepositorioBase<ContactoCliente> repCcto, RepositorioContactos repCtps, Cuerpo cuerpo, DetallesCorreo detalles,
            AdjuntarArchivos adjuntar)
        {
            this._repUser = repUser;
            this._repCcto = repCcto;
            this._repCtps = repCtps;
            this._cuerpo = cuerpo;
            this._detalles = detalles;
            this._adjuntar = adjuntar;

            aObtener = new List<int>();
            app = new Outlook.Application();
            mailSelected = app.ActiveExplorer().Selection[1];
            mailSelected = new Outlook.MailItem();
        }

        public void Nuevo(Oferta Oferta, OfertaClientes ofClientes, Mercado mercado, bool incluyeRep)
        {
            int[] intAObtener = { mercado.IdKAM, mercado.IdKA, mercado.IdVendedor1, mercado.IdVendedor2, mercado.IdVendedor3 };
            aObtener.AddRange(intAObtener);
            List<Usuario> vendedoresOferta = _repUser.GetMultiIdAsync(aObtener).Result;
            ContactoCliente CtoCliente = _repCcto.GetByIdAsync(ofClientes.IdContacto).Result;
            List<ContactoCliente> CtosRepresentantes = _repCtps.GetAllByClientIdAsync(ofClientes.IdRep1, (int)VendorEUEnum.Vendor).Result;
            string body = _cuerpo.Agregar(Oferta, ofClientes, CtoCliente, CtosRepresentantes, vendedoresOferta, incluyeRep);

            if (mailSelected == null) { mailReply = app.CreateItem(Outlook.OlItemType.olMailItem); }
            else { mailReply = mailSelected.ReplyAll(); }
            
            mailReply.HTMLBody = body + mailReply.HTMLBody + mailSelected.HTMLBody;

            _detalles.Agregar(mailReply, mailSelected, vendedoresOferta, Oferta, ofClientes, CtoCliente, CtosRepresentantes);
            _adjuntar.Oferta(Oferta, mailReply);

            mailReply.Display();
        }
    }
}
