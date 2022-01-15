using Model;
using Model.ReadModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepositorioEquiposLinkeados
    {
        Task<List<BaseInstalada>> GetByOfferIdAsync(int id);
        Task<List<EquiposLinkeadosCRM>> GetEquiposConInfoCRMByOfferIdAsync(int id);
    }
}