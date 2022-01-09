using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepositorioBase<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetMultiIdAsync(List<int> list);
        Task<List<T>> GetAllAsync();
        Task<int> AddAsync(T modelToInsert);
        Task<bool> UpdateAsync(T modelToInsert);
    }
}