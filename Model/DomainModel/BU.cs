using Dapper.Contrib.Extensions;
using System;

namespace Model
{
    [Table("BU")]
    public class BU
    {
        [Key]
        public int Id { get; set; }
        public string Acronimo { get; set; }
        public string Nombre { get; set; }
        [Computed]
        public string NombreCompleto { get { return $"{Acronimo} - {Nombre}"; } }
        public string Pais { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string CodigoPostal { get; set; }
        [Computed]
        public string DireccionCompleta { get { return $"{Direccion}, {Ciudad}, {Pais} - CP: {CodigoPostal}"; } }
        public string IdTributario { get; set; }
        public string Documento { get; set; }
        public double ValorDocumento { get; set; }
        public string IdMonedaDocumento { get; set; }
        [Computed]
        public string DocumentoInfo { get { 
                return String.IsNullOrEmpty(Documento) ? "N/A" : $"{Documento}, {IdMonedaDocumento} {ValorDocumento}"; 
            } }
    }
}

