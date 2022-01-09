using Dapper.Contrib.Extensions;

namespace Model
{
    [Table("Proceso")]
    public class Proceso
    {
        [Key]
        public int Id { get; set; }
        public string Aplicacion { get; set; }
    }
}

