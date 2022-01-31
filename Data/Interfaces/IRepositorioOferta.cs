using Model.ReadModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepositorioOferta
    {
        Task<List<OfertaCompleta>> GetAllByStateAsync(string estadoOfertasATraer);
    }
}