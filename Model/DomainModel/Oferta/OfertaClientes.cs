using Dapper.Contrib.Extensions;

namespace Model
{
    [Table("OfertaClientes")]
    public class OfertaClientes
    {
        [Key]
        public int Id { get; set; }
        public int IdOferta { get; set; }
        public int IdEndUser { get; set; }
        public int IdVendor { get; set; }
        public int IdRep1 { get; set; }
        public int IdRep2 { get; set; }
        public int IdContacto { get; set; }
    }
}
