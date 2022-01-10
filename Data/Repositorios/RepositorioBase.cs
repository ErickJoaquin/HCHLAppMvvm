using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class RepositorioBase<T> where T : class, new()
    {
        private readonly string RutaBBDD = @"Server=LCLSCLW10X0059\SQLEXPRESS; Database=BDHCHLApp; Integrated Security=True;";
        protected Type _typeOfProperty = typeof(T);

        public async Task<T> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                var value = await connection.QueryFirstOrDefaultAsync<T>($"SELECT * FROM {_typeOfProperty.Name} WHERE Id = {id}");

                return value;
            }
        }

        public async Task<List<T>> GetMultiIdAsync(List<int> list)
        {
            string sqlQuery = $"SELECT * FROM {_typeOfProperty.Name} WHERE Id = ";
            if(list.Count() > 1) 
            {
                sqlQuery += string.Join($" OR Id = ", list); 
            }
                        
            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                IEnumerable<T> value = await connection.QueryAsync<T>(sqlQuery);

                return (List<T>)value;
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                IEnumerable<T> value = await connection.QueryAsync<T>($"SELECT * FROM {_typeOfProperty.Name}");

                return (List<T>)value;
            }
        }

        public async Task<int> AddAsync(T modelToInsert)
        {
            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                var value = await connection.InsertAsync<T>(modelToInsert);

                return value;
            }
        }

        public async Task<bool> UpdateAsync(T modelToInsert)
        {
            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                var value = await connection.UpdateAsync<T>(modelToInsert);

                return value;
            }
        }
    }
}
