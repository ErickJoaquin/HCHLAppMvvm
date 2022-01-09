using Dapper.Contrib.Extensions;

namespace Model.ReadModel
{
    [Table("EquiposLinkeadosCRM")]
    public class EquiposLinkeadosCRM
    {
        [Key]
        public int Id { get; set; }
        public string NSerie { get; set; }
        public string Modelo { get; set; }
        public int IdProceso { get; set; }
        public string RefCliente { get; set; }
        public string IdEquiposCRM { get; set; }
        public string TipoEquipo { get; set; }
        public string Producto { get; set; }
        public string Maquina { get; set; }
    }
}

