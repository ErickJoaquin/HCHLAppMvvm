using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Model.ReadModel;

namespace Data.Repositorios
{
    public class RepositorioOferta : IRepositorioOferta
    {
        private readonly string RutaBBDD = @"Server=LCLSCLW10X0059\SQLEXPRESS; Database=BDHCHLApp; Integrated Security=True;";

        public async Task<List<OfertaCompleta>> GetAllAsync()
        {
            string sqlQuery = $"SELECT Oferta.Id, Oferta.NCRM, Oferta.Rev, Oferta.ReferenciaCliente, Oferta.GM, Oferta.VentaTotal, Oferta.IdMoneda, Oferta.IdProveedor, " +
                $"EU.Nombre, EU.Planta, VD.Nombre, MK.Segmento, MK.Referencia, US.Nombres, US.Apellidos, K.Nombres, K.Apellidos " +
                $"FROM Oferta " +
                $"INNER JOIN OfertaClientes AS OfCl on OfCl.IdOferta = Oferta.Id " +
                $"LEFT JOIN EndUser AS EU on EU.Id = OfCl.IdEndUser " +
                $"LEFT JOIN Vendor AS VD on VD.Id = OfCl.IdVendor " +
                $"INNER JOIN Mercado AS MK on MK.Id = Oferta.IdSubIndustria " +
                $"INNER JOIN Usuario AS K on K.Id = MK.IdKAM " +
                $"INNER JOIN Usuario AS US on US.Id = Oferta.IdAplicador ";

            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                var value = await connection.QueryAsync<OfertaCompleta>(sqlQuery);

                return value.ToList();
            }
        }

    }
}