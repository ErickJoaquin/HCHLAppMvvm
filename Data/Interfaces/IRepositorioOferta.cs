using Model.ReadModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public interface IRepositorioOferta
    {
        Task<List<OfertaCompleta>> GetAllAsync();
    }
}