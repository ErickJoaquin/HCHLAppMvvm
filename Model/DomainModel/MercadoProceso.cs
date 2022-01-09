using Dapper.Contrib.Extensions;

namespace Model
{
    [Table("MercadoProceso")]
    public class MercadoProceso
    {
        [Key]
        public int Id { get; set; }
        public int IdSubIndustria { get; set; }
        public int IdProceso { get; set; }
    }
}

