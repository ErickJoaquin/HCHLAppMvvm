using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class RepositorioMarca
    {
        public static List<Marca> ListadoMarcas { get; set; }

        public static List<Marca> Ventiladores()
        {
            ListadoMarcas = new List<Marca>();
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "Howden" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "Donkin Fans" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "Garden City Fans" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "Howden Buffalo" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "Convent Fan" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "Solyvent-Ventec" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "Buffalo Forge" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "Stork Fans" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "Wolf Fans" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "American Blower" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "Canadian Blower" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "Sirocco" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "Airscrew" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "Berry Fans" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "Variax" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Fans", Nombre = "Turbowerke Meissen" });

            return ListadoMarcas;
        }

        public static List<Marca> Compresores()
        {
            ListadoMarcas = new List<Marca>();
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Compressor", Nombre = "Howden" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Compressor", Nombre = "Roots" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Compressor", Nombre = "KK&K" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Compressor", Nombre = "ExVel" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Compressor", Nombre = "HV-Turbo" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Compressor", Nombre = "Brian Donkin" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Compressor", Nombre = "Burton Corblin" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Compressor", Nombre = "Donkin Blowers" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Compressor", Nombre = "Howden Thomassen" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Compressor", Nombre = "Austcold" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Compressor", Nombre = "Turblex" });

            return ListadoMarcas;
        }

        public static List<Marca> Intercambiadores()
        {
            ListadoMarcas = new List<Marca>();
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Heat Exchanger", Nombre = "Howden" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Heat Exchanger", Nombre = "Howden Sirocco Fans & Heaters" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "Heat Exchanger", Nombre = "Tallares Sanchez Luengo" });

            return ListadoMarcas;
        }

        public static List<Marca> Turbinas()
        {
            ListadoMarcas = new List<Marca>();
            ListadoMarcas.Add(new Marca() { TipoEquipo = "SteamTurbines", Nombre = "KK&K" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "SteamTurbines", Nombre = "Howden" });
            ListadoMarcas.Add(new Marca() { TipoEquipo = "SteamTurbines", Nombre = "Howden Steam Turbines" });

            return ListadoMarcas;
        }
    }
}
