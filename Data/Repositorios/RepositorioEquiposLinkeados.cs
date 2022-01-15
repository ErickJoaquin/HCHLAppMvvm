using Dapper;
using Model;
using Model.ReadModel;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces;

namespace Data
{
    public class RepositorioEquiposLinkeados : IRepositorioEquiposLinkeados
    {
        private readonly string RutaBBDD = @"Server=LCLSCLW10X0059\SQLEXPRESS; Database=BDHCHLApp; Integrated Security=True;";

        public async Task<List<BaseInstalada>> GetByOfferIdAsync(int id)
        {
            string sqlQuery = $"SELECT * FROM OfertaBaseInstalada " +
                $"INNER JOIN BaseInstalada on BaseInstalada.Id = OfertaBaseInstalada.IdEquipo " +
                $"WHERE OfertaBaseInstalada.IdOferta = {id}";

            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                var value = await connection.QueryAsync<BaseInstalada>(sqlQuery);

                return value.ToList();
            }
        }

        public async Task<List<EquiposLinkeadosCRM>> GetEquiposConInfoCRMByOfferIdAsync(int id)
        {
            string sqlQuery = $"SELECT BI.Id, BI.Modelo, BI.NSerie, IdProceso, BI.RefCliente, CRM.IdEquiposCRM, CRM.TipoEquipo, CRM.Producto, CRM.Maquina " +
                $"FROM OfertaBaseInstalada as oBI " +
                $"INNER JOIN BaseInstalada as BI ON BI.Id = oBI.IdEquipo " +
                $"INNER JOIN EquiposCRM as CRM ON BI.IdEquiposCRM = CRM.Id " +
                $"WHERE oBI.IdOferta = {id}";

            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                var value = await connection.QueryAsync<EquiposLinkeadosCRM>(sqlQuery);

                return value.ToList();
            }
        }
    }
}
