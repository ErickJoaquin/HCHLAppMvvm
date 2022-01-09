using Model;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class RepositorioPais 
    {
        public static List<Pais> ListaPaises { get; set; }
        public static List<Pais> ListaPaisesSudAmerica { get; set; }
        public static List<Pais> ListaPaisesBUs { get; set; }

        public static List<Pais> SudAmerica()
        {
            ListaPaisesSudAmerica = new List<Pais>();
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Argentina", Abreviatura = "AR" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Bahamas", Abreviatura = "BT" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Belice", Abreviatura = "BZ" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Bolivia", Abreviatura = "BO" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Brasil", Abreviatura = "BR" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Chile", Abreviatura = "CL" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Colombia", Abreviatura = "CO" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Costa Rica", Abreviatura = "CR" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Cuba", Abreviatura = "CU" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Curazao", Abreviatura = "CW" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Ecuador", Abreviatura = "EC" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "El Salvador", Abreviatura = "SV" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Guatemala", Abreviatura = "GT" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Guayana Francesa", Abreviatura = "GF" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Guyana", Abreviatura = "GY" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Haití", Abreviatura = "HT" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Honduras", Abreviatura = "HN" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Jamaica", Abreviatura = "JM" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Nicaragua", Abreviatura = "NI" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Paraguay", Abreviatura = "PY" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Panama", Abreviatura = "PA" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Perú", Abreviatura = "PE" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Puerto Rico", Abreviatura = "PR" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "República Dominicana", Abreviatura = "DO" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Surinam", Abreviatura = "SR" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Trinidad & Tobago", Abreviatura = "TT" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Uruguay", Abreviatura = "UY" });
            ListaPaisesSudAmerica.Add(new Pais() { Nombre = "Venezuela", Abreviatura = "VE" });

            return ListaPaisesSudAmerica;
        }

        public static List<Pais> BUs()
        {
            ListaPaisesBUs = new List<Pais>();
            ListaPaisesBUs.Add(new Pais() { Nombre = "Alemania", Abreviatura = "DE" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Australia", Abreviatura = "AU" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Brasil", Abreviatura = "BR" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Canadá", Abreviatura = "CA" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Chile", Abreviatura = "CL" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "China", Abreviatura = "CN" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Dinamarca", Abreviatura = "DK" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "España", Abreviatura = "ES" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Estados Unidos", Abreviatura = "US" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Francia", Abreviatura = "FR" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Finlandia", Abreviatura = "FI" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Paises Bajos", Abreviatura = "NL" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Hungria", Abreviatura = "HU" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "India", Abreviatura = "IN" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Indonesia", Abreviatura = "ID" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Reino Unido", Abreviatura = "UK" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Italia", Abreviatura = "IT" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Japon", Abreviatura = "JP" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "México", Abreviatura = "MX" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Perú", Abreviatura = "PE" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "Republica Checa", Abreviatura = "CS" });
            ListaPaisesBUs.Add(new Pais() { Nombre = "SudÁfrica", Abreviatura = "ZA" });

            return ListaPaisesBUs;
        }

        public static string devolverNombrePais(string Ab)
        {
            ListaPaises = new List<Pais>();
            ListaPaises = SudAmerica();
            ListaPaises.AddRange(BUs());

            Pais PaisSeleccionado = new Pais();
            PaisSeleccionado = (Pais)ListaPaises.Where(x => x.Abreviatura == Ab).First();
            return PaisSeleccionado.Nombre;
        }

        public static string devolverAbreviaturaPais(string Pa)
        {
            ListaPaises = new List<Pais>();
            ListaPaises.AddRange(SudAmerica());
            ListaPaises.AddRange(BUs());

            Pais PaisSeleccionado = new Pais();
            PaisSeleccionado = (Pais)ListaPaises.Where(x => x.Nombre == Pa).First();
            return PaisSeleccionado.Abreviatura;
        }
    }
}
