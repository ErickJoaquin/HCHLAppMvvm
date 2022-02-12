using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepositorioRevisiones
    {
        List<int> GetRevisions(string ncrm);
        bool HasRevisions(string ncrm);
    }
}

