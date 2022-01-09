using Dapper.Contrib.Extensions;

namespace Model
{
    [Table("ServicioOtros")]
    public class ServicioOtros
    {
        [Key]
        public int Id { get; set; }
        public int IdServicio { get; set; }
        public string Otro1Desc { get; set; }
        public double Otro1Qty { get; set; }
        public double Otro1Costo { get; set; }
        public string Otro2Desc { get; set; }
        public double Otro2Qty { get; set; }
        public double Otro2Costo { get; set; }
        public string Otro3Desc { get; set; }
        public double Otro3Qty { get; set; }
        public double Otro3Costo { get; set; }
    }
}
