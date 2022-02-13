using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Utilidades;

namespace Model.ReadModel
{
    public class AccesoBIModel
    {
        [Key]
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string NSerie { get; set; }
        public string RefCiente { get; set; }
        public string Pais { get; set; }
        public string Nombre { get; set; }
        public string Planta { get; set; }
        [Computed]
        public string PlantaDisplay
        {
            get
            {
                if (Planta != null)
                {
                    return Planta;
                }
                else
                {
                    return "Unknown";
                }
            }
        }
        [Computed]
        public string TipoIDTributario
        {
            get
            {
                if (EndUser.Pais != null)
                {
                    return IDTributario.GetType(EndUser.Pais);
                }
                else
                {
                    return "Unknown";
                }
            }
        }
        public BaseInstalada Equipo { get; set; }
        public EndUser EndUser { get; set; }
        public BU Proveedor { get; set; }
        public Proceso Proceso { get; set; }
        public Mercado Mercado { get; set; }
        public EquiposCRM CRM { get; set; }
        public List<Oferta> Ofertas { get; set; }
        public List<Venta> Ventas { get; set; }
        public List<Servicio> Servicios { get; set; }
    }
}
