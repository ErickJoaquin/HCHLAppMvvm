using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Utilidades
{
    public class IDTributario
    {
        public string GetType(string country)
        {
            string Type = "";
            if (country == "AR") { Type = "CUIT:"; }
            else if (country == "BR") { Type = "CPF/CNPJ:"; }
            else if (country == "VE") { Type = "RIF:"; }
            else if (country == "CL" || country == "UY") { Type = "RUT:"; }
            else if (country == "CR") { Type = "NITE:"; }
            else if (country == "DO") { Type = "RNC:"; }
            else if (country == "BO" || country == "CO" || country == "PAN" || country == "ES" || country == "GU") { Type = "NIT:"; }
            else if (country == "PA" || country == "PE" || country == "NI" || country == "EC") { country = "RUC:"; }
            else if (country == "HN") { Type = "RTN:"; }

            return Type;
        }
    }
}
