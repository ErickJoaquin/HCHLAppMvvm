using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepositorioBase<T> where T : class, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetMultiIdAsync(List<int> list);
        Task<List<T>> GetAllAsync();
        Task<int> AddAsync(T modelToInsert);
        Task<bool> UpdateAsync(T modelToInsert);
    }
}