using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepositorioPorOferta<T> where T : class, new()
    {
        Task<List<T>> GetAllByOfferIdAsync(int id);
        Task<T> GetByOfferIdAsync(int id);
    }
}