using System.Collections.Generic;
using Data.Interfaces;
using Model.ReadModel;

namespace Data
{
    public class RepositorioTablasBD : IRepositorioTablasBD
    {
        public List<TablasBD> GetAll()
        {
            List<TablasBD> Tablas = new List<TablasBD>();
            Tablas.Add(new TablasBD() { NombreEnBD = "BaseInstalada", NombreAMostrar = "Base Instalada" });
            Tablas.Add(new TablasBD() { NombreEnBD = "BU", NombreAMostrar = "BUs" });
            Tablas.Add(new TablasBD() { NombreEnBD = "ContactoCliente", NombreAMostrar = "Contacto de clientes" });
            Tablas.Add(new TablasBD() { NombreEnBD = "ContactoBU", NombreAMostrar = "Contactos BUs" });
            Tablas.Add(new TablasBD() { NombreEnBD = "EndUser", NombreAMostrar = "End Users" });
            Tablas.Add(new TablasBD() { NombreEnBD = "Pago", NombreAMostrar = "Formas de Pago" });
            Tablas.Add(new TablasBD() { NombreEnBD = "Usuario", NombreAMostrar = "Usuarios" });
            Tablas.Add(new TablasBD() { NombreEnBD = "Vendor", NombreAMostrar = "Vendors" });

            return Tablas;
        }
    }
}
