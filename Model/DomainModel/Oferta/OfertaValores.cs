using Dapper.Contrib.Extensions;

namespace Model
{
    [Table("OfertaValores")]
    public class OfertaValores
    {
        [Key]
        public int Id { get; set; }
        public int IdOferta { get; set; }
        public double MUP { get; set; }
        public double Packaging { get; set; }
        public double PackagingV { get; set; }
        public double DescuentoProveedor { get; set; }
        public double MN { get; set; }
        public double RAdicional { get; set; }
        public double Ing { get; set; }
        public double Fin { get; set; }
        public double BFielCumplimiento { get; set; }
        public double BAdelanto { get; set; }
        public double BCalidadGarantia { get; set; }
        public double Transporte { get; set; }
        public double TransporteV { get; set; }
        public double Aduana { get; set; }
        public double AduanaV { get; set; }

        public OfertaValores()
        {
            MUP = 1.5;
            MN = 3;
            RAdicional = 2;
            Fin = 1;
            Ing = 1;
            BAdelanto = 0;
            BCalidadGarantia = 0;
            BFielCumplimiento = 0;
            Packaging = 0;
            PackagingV = 0;
            Aduana = 0;
            AduanaV = 0;
            Transporte = 0;
            TransporteV = 0;
        }
    }
}
