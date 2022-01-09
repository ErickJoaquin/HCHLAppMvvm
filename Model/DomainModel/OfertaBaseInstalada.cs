using Dapper.Contrib.Extensions;

namespace Model
{
    [Table("OfertaBaseInstalada")]
    public class OfertaBaseInstalada
    {
        [Key]
        public int Id { get; set; }
        public int IdOferta { get; set; }
        public int IdEquipo { get; set; }
    }
}
