using Dapper.Contrib.Extensions;

namespace Model
{
    [Table("EquiposCRM")]
    public class EquiposCRM
    {
        [Key]
        public int Id { get; set; }
        public string IdEquiposCRM { get; set; }
        public string TipoEquipo { get; set; }
        public string Producto { get; set; }
        public string Maquina { get; set; }
    }
}
