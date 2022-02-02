using Dapper.Contrib.Extensions;
using System;

namespace Model
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string IdCRM { get; set; }
        public string Nombre { get; set; }
        [Computed]
        public int IdTipoCliente { get; set; }
        public string TipoCliente { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Region { get; set; }
        [Computed]
        public string DireccionCompleta
        {
            get
            {
                return Direccion + ", " + Ciudad + ", " + Pais + " - CP:" + CodigoPostal;
            }
        }
        public string IdTributario { get; set; }
        public string CodigoPostal { get; set; }
        public string PaginaWeb { get; set; }
        public string Telefono { get; set; }
        public int IdSubIndustria { get; set; }
        public int IdPagoEstandar { get; set; }
        public int IdEntregaEstandar { get; set; }
    }

    [Table("EndUser")]
    public class EndUser : Cliente
    {
        public string IdCRMPlanta { get; set; }
        public string Planta { get; set; }
        public string DireccionOf { get; set; }

        public EndUser()
        {
            IdTipoCliente = (int)VendorEUEnum.EU;
        }

        public override string ToString()
        {
            return String.IsNullOrEmpty(Planta) ? $"{Nombre}" : $"{Nombre} - {Planta}";
        }
    }

    [Table("Vendor")]
    public class Vendor : Cliente
    {
        public double Comision { get; set; }
        public bool EstadoComision { get; set; }
        public Vendor()
        {
            IdTipoCliente = (int)VendorEUEnum.Vendor;
        }
    }

    
}
