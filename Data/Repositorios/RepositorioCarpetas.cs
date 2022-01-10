using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dapper;

namespace Data
{
    public class RepositorioCarpetas
    {
        private readonly string RutaBBDD = @"Server=LCLSCLW10X0059\SQLEXPRESS; Database=BDHCHLApp; Integrated Security=True;";

        public async Task<string> GetPathAsync(int IdBU, string nombreCarpeta)
        {
            string sqlQuery = $"SELECT Ruta FROM Carpeta WHERE (IdBU = {IdBU} AND Nombre LIKE '{nombreCarpeta}') ";

            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                var value = await connection.QueryFirstOrDefaultAsync<Carpeta>(sqlQuery);

                return value.Ruta;
            }
        }

        public async Task<List<string>> GetPathsAsync(List<(int, string)> list)
        {
            string sqlQuery = $"SELECT Ruta FROM Carpeta WHERE (IdBU = {list[0].Item1} AND Nombre LIKE '{list[0].Item2}') ";
            if (list.Count() > 1)
            {
                for(int i = 1; i < list.Count(); i++)
                {
                    sqlQuery += $" OR (IdBU = {list[i].Item1} AND Nombre LIKE '{list[i].Item2}') ";
                }
            }

            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                List<string> listaRutas = new List<string>();
                IEnumerable<Carpeta> value = await connection.QueryAsync<Carpeta>(sqlQuery);

                foreach (Carpeta pasta in value)
                {
                    listaRutas.Add(pasta.Ruta);
                }

                return listaRutas;
            }            
        }
    }
}
