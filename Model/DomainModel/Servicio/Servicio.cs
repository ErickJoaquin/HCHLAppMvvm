using Dapper.Contrib.Extensions;

namespace Model
{
    [Table("Servicio")]
    public class Servicio : Item
    {
        public string TipoServicio { get; set; }
        public string DescripcionServicio { get; set; }
        public double NTecnicos { get; set; }
        public double CostoHH { get; set; }
        public double VentaHH { get; set; }
        public double DiasHabil { get; set; }
        public double DiasSabado { get; set; }
        public double DiasDomingo { get; set; }
        public double HHExtra { get; set; }
        public double HHEntrenamiento { get; set; }
        public double HHCapacitacion { get; set; }       


        public Servicio()
        {
            TipoItem = TipoItemEnum.SV.ToString();
        }
    }
}
