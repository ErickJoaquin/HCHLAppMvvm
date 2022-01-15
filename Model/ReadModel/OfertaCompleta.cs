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
        public string NCRM { get; set; }
        public int Rev { get; set; }
        public int IdEndUser { get; set; }
        public int IdVendor { get; set; }
        public string ReferenciaCliente { get; set; }
        public int IdMoneda { get; set; }
        public double VentaTotal { get; set; }
        public double GM { get; set; }
        public int IdProveedor { get; set; }
        public int IdSubIndustria { get; set; }
        public int IdTipoEntrega { get; set; }
        public string DireccionEntrega { get; set; }
        public int IdAplicador { get; set; }
        public string IdEquiposCRM { get; set; }
        public string TipoEquipo { get; set; }
        public string Producto { get; set; }
        public string Maquina { get; set; }
        public string Referencia { get; set; }
        public int IdKAM { get; set; }
        public string Estado { get; set; }
        public string TipoOferta { get; set; }
    }
}
