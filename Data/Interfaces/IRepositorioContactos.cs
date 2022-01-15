using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepositorioContactos
    {
        Task<List<ContactoCliente>> GetAllByClientIdAsync(int id, int tipo);
    }
}