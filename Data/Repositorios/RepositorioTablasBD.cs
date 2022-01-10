using System.Collections.Generic;
using Model.ReadModel;

namespace Data
{
    public class RepositorioTablasBD
    {
        public List<TablasBD> GetAll()
        {
            List<TablasBD> Tablas = new List<TablasBD>();
            Tablas.Add(new TablasBD() { NombreEnBD = "BaseInstalada", NombreAMostrar = "Base Instalados" });
            Tablas.Add(new TablasBD() { NombreEnBD = "BU", NombreAMostrar = "BUs" });
            Tablas.Add(new TablasBD() { NombreEnBD = "ContactoClientes", NombreAMostrar = "Contacto de clientes" });
            Tablas.Add(new TablasBD() { NombreEnBD = "ContactoBU", NombreAMostrar = "Contactos BUs" });
            Tablas.Add(new TablasBD() { NombreEnBD = "EndUser", NombreAMostrar = "End Users" });
            Tablas.Add(new TablasBD() { NombreEnBD = "Pago", NombreAMostrar = "Fromas de Pago" });
            Tablas.Add(new TablasBD() { NombreEnBD = "Usuario", NombreAMostrar = "Usuarios" });
            Tablas.Add(new TablasBD() { NombreEnBD = "Vendor", NombreAMostrar = "Vendors" });

            return Tablas;
        }
    }
}
