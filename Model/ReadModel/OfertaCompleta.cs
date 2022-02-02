using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ReadModel
{
    public class OfertaCompleta
    {
        [Key]
        public int Id { get; set; }
        public int IdBU { get; set; }
        [Computed]
        public string BU
        {
            get
            {
                return ((BUEnum)IdBU).ToString();
            }
        }
        public string NCRM { get; set; }
        public int Rev { get; set; }
        public int? IdEndUser { get; set; }
        public int? IdVendor { get; set; }
        public string NombreEndUser { get; set; }
        public string Planta { get; set; }
        public string NombreVendor { get; set; }
        [Computed]
        public string Cliente 
        {
            get
            {
                if(String.IsNullOrEmpty(NombreVendor))
                {
                    return (!String.IsNullOrEmpty(Planta)) ? $"{NombreEndUser} - {Planta}" : $"{NombreEndUser}";
                }
                else
                {
                    return $"{NombreVendor}";
                }
            }
        }
        public string ReferenciaCliente { get; set; }
        public int IdMoneda { get; set; }
        public string Moneda
        {
            get
            {
                return ((MonedasEnum)IdMoneda).ToString();
            }
        }
        public double VentaTotal { get; set; }
        public double GM { get; set; }
        public int IdProveedor { get; set; }
        //public BU Proveedor { get; set; }
        public string ProveedorAcronimo { get; set; }
        public string ProveedorNombre { get; set; }
        [Computed]
        public string Proveedor 
        {
            get
            {
                return $"{ProveedorAcronimo} - {ProveedorNombre}";
            }
        }
        public int IdSubIndustria { get; set; }
        public int IdTipoEntrega { get; set; }
        [Computed]
        public string TipoEntrega
        {
            get
            {
                return ((TipoEntregaEnum)IdTipoEntrega).ToString();
            }
        }
        public string DireccionEntrega { get; set; }
        public int IdAplicador { get; set; }
        //public Usuario Aplicador { get; set; }
        public string AplicadorNombre { get; set; }
        public string AplicadorApellido { get; set; }
        [Computed]
        public string Aplicador
        {
            get
            {
                return $"{AplicadorNombre} {AplicadorApellido}";
            }
        }
        public string IdEquiposCRM { get; set; }
        public string TipoEquipo { get; set; }
        public string Producto { get; set; }
        public string Maquina { get; set; }
        public string Segmento { get; set; }
        public string Referencia { get; set; }
        public int IdKAM { get; set; }
        //public Usuario Vendedor { get; set; }  // aplicar esto y eliminar el resto de las propieades asociadas
        public string VendedorNombre { get; set; }
        public string VendedorApellido { get; set; }
        [Computed]
        public string Vendedor
        {
            get
            {
                return $"{VendedorNombre} {VendedorApellido}";
            }
        }
        public string Estado { get; set; }
        public string TipoOferta { get; set; }
        public string NPV { get; set; }
        public string NombreOC { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
