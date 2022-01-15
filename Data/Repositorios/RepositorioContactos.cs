using Dapper;
using Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Data.Interfaces;

namespace Data
{
    public class RepositorioContactos : IRepositorioContactos
    {
        private readonly string RutaBBDD = @"Server=LCLSCLW10X0059\SQLEXPRESS; Database=BDHCHLApp; Integrated Security=True;";
        public async Task<List<ContactoCliente>> GetAllByClientIdAsync(int id, int tipo)
        {
            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                string sqlQuery = "";
                if (tipo == (int)VendorEUEnum.Vendor)
                {
                    sqlQuery = $"SELECT * FROM ContactoCliente WHERE IdVendor = {id}";
                }
                else
                {
                    sqlQuery = $"SELECT * FROM ContactoCliente WHERE IdEndUser = {id}";
                }

                IEnumerable<ContactoCliente> value = await connection.QueryAsync<ContactoCliente>(sqlQuery);

                return (List<ContactoCliente>)value;
            }
        }

    }
}
