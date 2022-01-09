using Dapper.Contrib.Extensions;
namespace Model
{
    [Table("Repuesto")]
    public class Repuesto : Item
    {
        public string NParte { get; set; }
        public double GMUnitario { get; set; }
        public string Drw { get; set; }
        public string DrwItem { get; set; }
        public string HSCode { get; set; }
        public string Comentarios { get; set; }
        public string RefCliente { get; set; }
        public int PlazoEntrega { get; set; }
        public double ParticipacionUnitaria { get; set; }

        public Repuesto()
        {
            TipoItem = TipoItemEnum.SP.ToString();
        }
    }
}
