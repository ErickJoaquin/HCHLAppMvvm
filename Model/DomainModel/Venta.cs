using Dapper.Contrib.Extensions;

namespace Model
{
    [Table("Venta")]
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        public string NPV { get; set; }
        public int IdBU { get; set; }
        public int IdOferta { get; set; }
        public int IdOC { get; set; }
    }
}
