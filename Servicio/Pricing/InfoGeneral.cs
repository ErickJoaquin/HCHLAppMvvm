using Model;
using Model.ReadModel;
using Data;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using Servicios.Utilidades;
using System.Collections.Generic;

namespace Servicios.Pricing
{
    public class InfoGeneral
    {
        public void Agregar(Excel.Worksheet HojaPricing, Excel.Worksheet HojaPersonal, Oferta Oferta, OfertaClientes ofClientes, 
            Mercado Mercado, bool incluyeRep, bool Consolidando)
        {
            RepositorioBase<BU> _repBU = new RepositorioBase<BU>();
            BU BU = _repBU.GetByIdAsync(Oferta.IdBU).Result;

            RepositorioBase<EndUser> _repEU = new RepositorioBase<EndUser>();
            var infoCliente = new InformacionCliente();
            Cliente Cliente = infoCliente.obtener(Oferta);
            EndUser EU = new EndUser();
            if (Cliente.IdTipoCliente == (int)VendorEUEnum.EU) { EU = Cliente as EndUser; }
            else { EU = _repEU.GetByIdAsync(ofClientes.IdEndUser).Result; }

            RepositorioBase<ContactoCliente> _repCtos = new RepositorioBase<ContactoCliente>();
            ContactoCliente CtoCliente = _repCtos.GetByIdAsync(ofClientes.IdContacto).Result;

            RepositorioBase<Pago> _repPagos = new RepositorioBase<Pago>();
            Pago Pago = _repPagos.GetByIdAsync(Oferta.IdTipoPago).Result;

            RepositorioEquiposLinkeados _repBILinkes = new RepositorioEquiposLinkeados();
            List<EquiposLinkeadosCRM> EquiposLinkeados = _repBILinkes.GetEquiposConInfoCRMByOfferIdAsync(Oferta.Id).Result;

            RepositorioBase<Usuario> _repUser = new RepositorioBase<Usuario>();
            Usuario User = _repUser.GetByIdAsync(Oferta.IdAplicador).Result;

            RepositorioBase<Vendor> _repRep = new RepositorioBase<Vendor>();
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
