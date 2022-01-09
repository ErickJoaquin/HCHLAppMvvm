using Dapper.Contrib.Extensions;
using System;

namespace Model
{
    [Table("OC")]
    public class OC
    {
        [Key]
        public int Id { get; set; }
        public int IdOferta { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
