using System;
using Model;
using Data.Interfaces;

namespace Servicios.Utilidades
{
    public class InformacionCliente
    {
        private readonly IRepositorioBase<EndUser> _repEU;
        private readonly IRepositorioBase<Vendor> _repVendor;
        public Cliente Cliente;
        public InformacionCliente(IRepositorioBase<EndUser> repEU, IRepositorioBase<Vendor> repVendor)
        {
            this._repEU = repEU;
            this._repVendor = repVendor;

            Cliente = new Cliente();
        }

        public Cliente Obtener(OfertaClientes ofCliente)
        {
            if (String.IsNullOrEmpty(ofCliente.IdVendor.ToString()))
            {
                Cliente = _repEU.GetByIdAsync(ofCliente.IdEndUser).Result;
                Cliente.IdTipoCliente = (int)VendorEUEnum.EU;
            }
            else 
            { 
                Cliente = _repVendor.GetByIdAsync(ofCliente.IdVendor).Result; 
                Cliente.IdTipoCliente = (int)VendorEUEnum.Vendor;
            }

            return Cliente;
        }
    }
}
