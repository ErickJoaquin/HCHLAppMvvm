﻿using Dapper;
using Data.Interfaces;
using Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class RepositorioRevisiones : IRepositorioRevisiones
    {
        private readonly string RutaBBDD = @"Server=LCLSCLW10X0059\SQLEXPRESS; Database=BDHCHLApp; Integrated Security=True;";

        public List<int> GetRevisions(string ncrm)
        {
            string sqlQuery = $"SELECT Id " +
                $"FROM Oferta " +
                $"WHERE NCRM LIKE '{ncrm}'";

            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                var value = connection.Query<Oferta>(sqlQuery);

                return value.Select(x => x.Id).ToList();
            }
        }

        public bool HasRevisions(string ncrm)
        {
            string sqlQuery = $"SELECT Id " +
                $"FROM Oferta " +
                $"WHERE NCRM LIKE '{ncrm}'";

            using (var connection = new SqlConnection(RutaBBDD))
            {
                connection.Open();

                var value = connection.Query<Oferta>(sqlQuery);

                return value.Any();
            }
        }
    }
}