using System;
using Model;
using Data;

namespace Servicios.Utilidades
{
    public class InformacionCliente
    {
        public Cliente obtener(Oferta Oferta)
        {
            Cliente Cliente = new Cliente();
            OfertaClientes ofCliente = new OfertaClientes();
            RepositorioBase<EndUser> repEU = new RepositorioBase<EndUser>();
            RepositorioBase<Vendor> repVendor = new RepositorioBase<Vendor>();

            if (String.IsNullOrEmpty(ofCliente.IdVendor.ToString()))
            {
                Cliente = repEU.GetByIdAsync(ofCliente.IdEndUser).Result;
                Cliente.IdTipoCliente = (int)VendorEUEnum.EU;
            }
            else 
            { 
                Cliente = repVendor.GetByIdAsync(ofCliente.IdVendor).Result; 
                Cliente.IdTipoCliente = (int)VendorEUEnum.Vendor;
            }

            return Cliente;
        }
    }
}
