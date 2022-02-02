using Dapper.Contrib.Extensions;

namespace Model
{
    [Table("BaseInstalada")]
    public class BaseInstalada
    {
        [Key]
        public int Id { get; set; }
        public string NSerie { get; set; }
        public string Modelo { get; set; }
        public string Familia { get; set; }
        public int IdEquiposCRM { get; set; }
        public int IdBU { get; set; }
        public int IdEU { get; set; }
        public int IdProceso { get; set; }
        public string NContrato { get; set; }
        public string Marca { get; set; }
        public string AnoInstalacion { get; set; }
        public string EstadoOperacion { get; set; }
        public int IdSubIndustria { get; set; }
        public string RefCliente { get; set; }
        public string DetallesModelo { get; set; }
        public string Especificaciones { get; set; }
        public string InformacionExtra { get; set; }
        [Computed]
        public bool seleccion { get; set; } // Para ver si esta incluido o no en la oferta

        public override string ToString()
        {
            return $"{Modelo} - {NSerie}";
        }
    }
}

