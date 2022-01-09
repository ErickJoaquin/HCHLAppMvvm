using Dapper.Contrib.Extensions;

namespace Model
{
    [Table("ServicioCantidades")]
    public class ServicioCantidades
    {
        [Key]
        public int Id { get; set; }
        public int IdServicio { get; set; }
        public double HMOQty { get; set; }
        public double HIngQty { get; set; }
        public double MovilizacionQty { get; set; }
        public double PasajesQty { get; set; }
        public double DocumentosQty { get; set; }
        public double DiaCarroQty { get; set; }
        public double NocheAlojamientoQty { get; set; }
        public double DiaAlimentacionQty { get; set; }
        public double TrasladoQty { get; set; }
        public double APSQty { get; set; }
        public double WHoldingQty { get; set; }
    }
}
