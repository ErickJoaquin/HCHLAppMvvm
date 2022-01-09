using Dapper.Contrib.Extensions;

namespace Model
{
    [Table("ServicioCostos")]
    public class ServicioCostos
    {
        [Key]
        public int Id { get; set; }
        public int IdServicio { get; set; }
        public double HMOCosto { get; set; }
        public double HIngCosto { get; set; }
        public double MovilizacionCosto { get; set; }
        public double PasajeCosto { get; set; }
        public double DocumentosCosto { get; set; }
        public double DiaCarroCosto { get; set; }
        public double NocheAlojamientoCosto { get; set; }
        public double DiaAlimentacionCosto { get; set; }
        public double TrasladoCosto { get; set; }
        public double APSCosto { get; set; }
        public double WHoldingCosto { get; set; }
    }
}
