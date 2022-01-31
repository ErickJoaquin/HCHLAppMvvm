using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Data.Interfaces;
using Model.ReadModel;

namespace Data.Repositorios
{
    public class RepositorioOferta : IRepositorioOferta
    {
        private readonly string RutaBBDD = @"Server=LCLSCLW10X0059\SQLEXPRESS; Database=BDHCHLApp; Integrated Security=True;";

        public async Task<List<OfertaCompleta>> GetAllByStateAsync(string estadoOfertasATraer)
        {
            bool venta = (estadoOfertasATraer == "Consolidando" || estadoOfertasATraer == "Vendida") ? true : false;

            string sqlQuery = $"SELECT Oferta.Id, Oferta.IdBU, Oferta.NCRM, Oferta.Rev, Oferta.ReferenciaCliente, Oferta.GM, Oferta.VentaTotal, Oferta.IdMoneda, " +
                $"Oferta.IdProveedor, Oferta.IdTipoEntrega, " +
                $"EU.Nombre AS NombreEndUser, EU.Planta AS Planta, VD.Nombre AS NombreVendor, MK.Segmento, MK.Referencia, US.Nombres AS AplicadorNombre, " +
                $"US.Apellidos AS AplicadorApellido, K.Nombres AS VendedorNombre, K.Apellidos AS VendedorApellido, ";
            sqlQuery += (venta) ? $"OC.FechaRecepcion, OC.FechaEntrega, OC.Nombre AS NombreOC, Venta.NPV, " : "";
            sqlQuery += $"BU.Acronimo AS ProveedorAcronimo, BU.Nombre AS ProveedorNombre " +
                $"FROM Oferta " +
                $"INNER JOIN OfertaClientes AS OfCl on OfCl.IdOferta = Oferta.Id " +
                $"LEFT JOIN EndUser AS EU on EU.Id = OfCl.IdEndUser " +
                $"LEFT JOIN Vendor AS VD on VD.Id = OfCl.IdVendor " +
                $"INNER JOIN Mercado AS MK on MK.Id = Oferta.IdSubIndustria " +
                $"INNER JOIN BU AS BU on BU.Id = Oferta.IdProveedor " +
                $"INNER JOIN Usuario AS K on K.Id = MK.IdKAM " +
                $"INNER JOIN Usuario AS US on US.Id = Oferta.IdAplicador ";
            sqlQuery += (venta) ? $"INNER JOIN OC on OC.IdOferta = Oferta.Id " : "";
            sqlQuery += (venta) ? $"INNER JOIN Venta on Venta.IdOferta = Oferta.Id " : "";
            sqlQuery += $"WHERE Oferta.Estado LIKE '{estadoOfertasATraer}'";

            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                var value = await connection.QueryAsync<OfertaCompleta>(sqlQuery);

                return value.ToList();
            }
        }

    }
}