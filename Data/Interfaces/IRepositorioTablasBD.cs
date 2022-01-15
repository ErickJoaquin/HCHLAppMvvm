using Model.ReadModel;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IRepositorioTablasBD
    {
        List<TablasBD> GetAll();
    }
}