using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Carpeta")]
    public class Carpeta
    {
        [Key]
        public int Id { get; set; }
        public int IdBU { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
    }
}
