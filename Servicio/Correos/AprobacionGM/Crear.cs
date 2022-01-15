using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Data;
using Outlook = Microsoft.Office.Interop.Outlook;
using Servicios.Utilidades;
using Utilidades.Correos.AprobacionGM.Utilidades;
using Data.Interfaces;

namespace Utilidades.Correos.AprobacionGM
{
    public class Crear
    {
        private readonly Cuerpo _cuerpo;
        private readonly InformacionCliente _infoCliente;
        private readonly IRepositorioBase<Usuario> _repUser;

        public Outlook.Application app { get; set; }
        Outlook.MailItem mailReply { get; set; }
        public List<int> VendedoresAObtener { get; set; }

        public Crear(Cuerpo cuerpo, InformacionCliente infoCliente, IRepositorioBase<Usuario> repUser)
        {
            this._cuerpo = cuerpo;
            this._infoCliente = infoCliente;
            this._repUser = repUser;

            app = new Outlook.Application();
            mailReply = new Outlook.MailItem();
            VendedoresAObtener = new List<int>();
        }

        public void Nuevo(Oferta Oferta, OfertaClientes ofClientes, OfertaValores ofValores, Mercado Mercado, double Comisiones, bool Consolidando, OC OC = null)
        {
            Cliente Cliente = _infoCliente.Obtener(ofClientes);            

            string body = _cuerpo.Agregar(Oferta, ofClientes, ofValores, Cliente, Comisiones, Consolidando, OC);

            VendedoresAObtener.Add(Mercado.IdKAM);
            VendedoresAObtener.Add(Mercado.IdKA);
            List<Usuario> vendedoresOferta = _repUser.GetMultiIdAsync(VendedoresAObtener).Result;

            string mailkam = vendedoresOferta.ElementAt(0).Mail;
            string mailka = "";
            if (vendedoresOferta.Count > 1) { mailka = vendedoresOferta.ElementAt(1).Mail; }

            object selectedObject = app.ActiveExplorer().Selection[1];
            Outlook.MailItem mailSelected = selectedObject as Outlook.MailItem;
            if (mailSelected == null) { mailReply = app.CreateItem(Outlook.OlItemType.olMailItem); }
            else { mailReply = mailSelected.Forward(); }

            mailReply.To = "edson.geraldini@howden.com";

            mailReply.CC = "marcos.pinto@howden.com; thais.trevine@howden.com; ";
            if (mailkam != "") { mailReply.CC += "; " + mailkam; }
            if (mailka != "") { mailReply.CC += "; " + mailka; }
            mailReply.Subject = $"Aprobación Pricing {Oferta.NCRM}-{Oferta.Rev} para {Cliente.Nombre}";

            mailReply.HTMLBody = body + mailReply.HTMLBody + mailSelected.HTMLBody;

            mailReply.Display();
        }
    }
}
