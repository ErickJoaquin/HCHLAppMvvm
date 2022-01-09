using Dapper.Contrib.Extensions;

namespace Model
{
    [Table("OfertaMonedas")]  
    public class OfertaMonedas
    {
        [Key]
        public int Id { get; set; }
        public int IdOferta { get; set; }
        public double EUR { get; set; }
        public double GBP { get; set; }
        public double USD { get; set; }
        public double CLP { get; set; }
        public double BRL { get; set; }
        public double SOL { get; set; }
    }
}
