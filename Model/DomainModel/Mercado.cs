using Dapper.Contrib.Extensions;

namespace Model
{
    [Table("Mercado")]
    public class Mercado
    {
        [Key]
        public int Id { get; set; }
        public string SubIndustria { get; set; }
        public string Industria { get; set; }
        public string Segmento { get; set; }
        public string Referencia { get; set; }
        public int IdKAM { get; set; }
        public int IdKA { get; set; }
        public int IdVendedor1 { get; set; }
        public int IdVendedor2 { get; set; }
        public int IdVendedor3 { get; set; }
    }
}

