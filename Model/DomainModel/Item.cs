using Dapper.Contrib.Extensions;

namespace Model
{
    public class Item
    {   
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IdOferta { get; set; }
        public string IdVenta { get; set; }
        public int IdMoneda { get; set; }
        public int Qty { get; set; }
        public double CostoUnitario { get; set; }
        public double VentaUnitaria { get; set; }
        public int NSP { get; set; }
        [Computed]
        public string TipoItem { get; set; } 
    }
}
