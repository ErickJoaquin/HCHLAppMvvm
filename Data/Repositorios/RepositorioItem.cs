using Model;
using System.Collections.Generic;
using Dapper;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq;
using Data.Interfaces;

namespace Data
{
    public class RepositorioItem : IRepositorioItem
    {
        public List<Item> GetByOffer(int Id)
        {
            RepositorioPorOferta<Repuesto> repSp = new RepositorioPorOferta<Repuesto>();
            RepositorioPorOferta<Servicio> repSv = new RepositorioPorOferta<Servicio>();

            List<Repuesto> spareList = repSp.GetAllByOfferIdAsync(Id).Result;
            List<Servicio> svList = repSv.GetAllByOfferIdAsync(Id).Result;

            List<Item> items = new List<Item>();
            items.AddRange(spareList);
            items.AddRange(svList);

            return items;
        }
    }
}
