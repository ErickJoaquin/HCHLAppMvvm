using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Data.Interfaces;

namespace Data
{
    public class RepositorioPorOferta<T> : IRepositorioPorOferta<T> where T : class, new()
    {
        private readonly string RutaBBDD = @"Server=LCLSCLW10X0059\SQLEXPRESS; Database=BDHCHLApp; Integrated Security=True;";
        protected Type _typeOfProperty = typeof(T);

        public async Task<T> GetByOfferIdAsync(int id)
        {
            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                var value = await connection.QueryFirstOrDefaultAsync<T>($"SELECT * FROM {_typeOfProperty.Name} WHERE IdOferta = @Id", new { Id = id });

                return value;
            }
        }

        public async Task<List<T>> GetAllByOfferIdAsync(int id)
        {
            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                IEnumerable<T> value = await connection.QueryAsync<T>($"SELECT * FROM {_typeOfProperty.Name}  WHERE IdOferta = @Id", new { Id = id });

                return (List<T>)value;
            }
        }
    }
}
