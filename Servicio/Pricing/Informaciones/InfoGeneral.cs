using Model;
using Model.ReadModel;
using Data;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using Servicios.Utilidades;
using System.Collections.Generic;

namespace Servicios.Pricing.Informaciones
{
    public class InfoGeneral
    {
        private readonly InformacionCliente _infoCliente;
        private readonly IRepositorioBase<BU> _repBU;
        private readonly IRepositorioBase<EndUser> _repEU;
        private readonly IRepositorioBase<ContactoCliente> _repCtos;
        private readonly IRepositorioBase<Usuario> _repUser;
        private readonly IRepositorioBase<Vendor> _repRep;
        private readonly RepositorioBase<Pago> _repPagos;
        private readonly RepositorioEquiposLinkeados _repBILinkes;

        public InfoGeneral(IRepositorioBase<BU> repBU, IRepositorioBase<EndUser> repEU, IRepositorioBase<ContactoCliente> repCtos, RepositorioBase<Pago> repPagos,
            IRepositorioBase<Usuario> repUser, IRepositorioBase<Vendor> repRep, InformacionCliente infoCliente, RepositorioEquiposLinkeados repBILinkes)
        {
            this._repBU = repBU;
            this._repEU = repEU;
            this._repCtos = repCtos;
            this._repPagos = repPagos;
            this._repUser = repUser;
            this._repRep = repRep;
            this._repBILinkes = repBILinkes;
            this._infoCliente = infoCliente;
        }

        public void Agregar(Excel.Worksheet HojaPricing, Excel.Worksheet HojaPersonal, Oferta Oferta, OfertaClientes ofClientes, 
            Mercado Mercado, bool incluyeRep, bool Consolidando)
        {
            BU BU = _repBU.GetByIdAsync(Oferta.IdBU).Result;
            Cliente Cliente = _infoCliente.Obtener(ofClientes);

            EndUser EU = new EndUser();
            if (Cliente.IdTipoCliente == (int)VendorEUEnum.EU) { EU = Cliente as EndUser; }
            else { EU = _repEU.GetByIdAsync(ofClientes.IdEndUser).Result; }

            ContactoCliente CtoCliente = _repCtos.GetByIdAsync(ofClientes.IdContacto).Result;
            Pago Pago = _repPagos.GetByIdAsync(Oferta.IdTipoPago).Result;
            List<EquiposLinkeadosCRM> EquiposLinkeados = _repBILinkes.GetEquiposConInfoCRMByOfferIdAsync(Oferta.Id).Result;
            Usuario User = _repUser.GetByIdAsync(Oferta.IdAplicador).Result;

            Vendor Representante = new Vendor();
            if (incluyeRep)
            {
                Representante = _repRep.GetByIdAsync(ofClientes.IdRep1).Result;
            }

            var _entrega = (TipoEntregaEnum)Oferta.IdTipoEntrega;
            var _moneda = (MonedasEnum)Oferta.IdMoneda;

            HojaPricing.Range["B1"].Value = (!String.IsNullOrEmpty(BU.Acronimo)) ? "PRICING " + BU.Acronimo : "PRICING";
            HojaPricing.Range["E4"].Value = (Cliente != null) ? Cliente.Nombre : "";
            HojaPricing.Range["E5"].Value = (CtoCliente != null) ? CtoCliente.NombreCompleto : "";
            HojaPricing.Range["E6"].Value = (Oferta.Estado == "Consolidando" || Oferta.Estado == "Vendida") ? Oferta.NPV : "";
            HojaPricing.Range["E7"].Value = (EquiposLinkeados.Count > 0) ? EquiposLinkeados[0].TipoEquipo : "";
            HojaPricing.Range["E8"].Value = (EquiposLinkeados.Count > 0) ? EquiposLinkeados[0].Producto : "";
            HojaPricing.Range["E9"].Value = (Mercado != null) ? Mercado.Referencia : "";
            HojaPricing.Range["I4"].Value = Oferta.NCRM;
            HojaPricing.Range["I5"].Value = "AFM";
            HojaPricing.Range["I6"].Value = (Cliente.IdTipoCliente == (int)VendorEUEnum.EU) ? "Cliente Final" : "Industrializacion/Reventa";
            HojaPricing.Range["I7"].Value = (Cliente.Pais == BU.Pais) ? "Nacional" : "Exportacion";
            HojaPricing.Range["I8"].Value = (incluyeRep) ? "Si" : "No";
            HojaPricing.Range["I9"].Value = (Oferta.PlazoEntrega > 0) ? Oferta.PlazoEntrega.ToString() : "";
            HojaPricing.Range["O4"].Value = (Oferta.IdTipoEntrega > 0) ? _entrega.ToString() : "";
            if (_entrega.ToString() == "ExW") { HojaPricing.Range["O4"].Value = "Ex-Works"; }
            HojaPricing.Range["P4"].Value = (String.IsNullOrEmpty(Oferta.DireccionEntrega)) ? Oferta.DireccionEntrega : "";
            HojaPricing.Range["O5"].Value = (Pago != null) ? Pago.Descripcion : "";
            HojaPricing.Range["O6"].Value = (Oferta.Validez > 0) ? Oferta.Validez.ToString() : "15";
            HojaPricing.Range["O7"].Value = (Oferta.IdMoneda > 0) ? _moneda.ToString() : "";
            HojaPricing.Range["L32"].Value = (incluyeRep) ? Representante.Nombre : "N/A";
            HojaPricing.Range["L33"].Value = (incluyeRep) ? Representante.Comision : 0;
            HojaPricing.Range["O9"].Value = (User != null) ? User.NombreCompleto : "";
            HojaPersonal.Range["B4"].Value = (User != null) ? User.IdUsuario : "";
        }
    }
}
