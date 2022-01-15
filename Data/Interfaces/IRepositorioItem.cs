using Model;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IRepositorioItem
    {
        List<Item> GetByOffer(int Id);
    }
}