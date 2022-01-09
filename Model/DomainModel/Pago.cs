using Dapper.Contrib.Extensions;

namespace Model
{
    [Table("Pago")]
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Pago1 { get; set; }
        public double Pago2 { get; set; }
        public double Pago3 { get; set; }
        public double Plazo1 { get; set; }
        public double Plazo2 { get; set; }
        public double Plazo3 { get; set; }
        public string Hito1 { get; set; }
        public string Hito2 { get; set; }
        public string Hito3 { get; set; }
    }
}
