using Dapper.Contrib.Extensions;
using System;

namespace Model
{
    [Table("Oferta")]
    public class Oferta
    {
        [Key]
        public int Id { get; set; }
        public int IdBU { get; set; }
        public string NCRM { get; set; }
        public int Rev { get; set; }
        public string Estado { get; set; }       
        public int IdMoneda { get; set; }
        public double CostoTotal { get; set; }
        public double VentaTotal { get; set; }
        [Computed]
        public double VLiquida { get; set; }
        public double GM { get; set; }
        public int IdTipoEntrega { get; set; }
        public int IdTipoPago { get; set; }
        public int Validez { get; set; }
        public int PlazoEntrega { get; set; }
        public int IdAplicador { get; set; }
        public string ReferenciaCliente { get; set; }
        public int IdProveedor { get; set; }
        public string Producto { get; set; }
        public int IdSubIndustria { get; set; }
        public string DireccionEntrega { get; set; }
        public int MonedaConsolidacion { get; set; }
        public double CambioConsolidacion { get; set; }
        public DateTime FechaConsolidacion { get; set; }
        public DateTime FechaTraspaso { get; set; }
        public string DetallesOferta { get; set; }
        public string NPV { get; set; }
        [Computed]
        public bool Nacional { get; set; }
        public string CalculoGM { get; set; }
        public string Idioma { get; set; }
        public DateTime FechaEdicion { get; set; }
        public string TipoOferta { get; set; } 
        
    }
}














