using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepositorioCarpetas
    {
        Task<string> GetPathAsync(int IdBU, string nombreCarpeta);
        Task<List<string>> GetPathsAsync(List<(int, string)> list);
    }
}