using Dapper.Contrib.Extensions;

namespace Model
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Mail { get; set; }
        public string Sexo { get; set; }
        public string Departamento { get; set; }
        public string Cargo { get; set; }
        public override string ToString()
        {
            return $"{Nombres} {Apellidos}";
        }
    }

    [Table("Usuario")]
    public class Usuario : Persona
    {
        public string IdUsuario { get; set; }
        public int IdBU { get; set; }
        public string Puesto { get; set; }
        public string DetallesFirma { get; set; }
    }

    [Table("ContactoBU")]
    public class ContactoBU : Persona
    {
        public int IdBU { get; set; }
        public string Tecnologia { get; set; }
        public string Marca { get; set; }
        public string Maquina { get; set; }
        [Computed]
        public int BUCliente { get; set; }

        public ContactoBU()
        {
            BUCliente = (int)TipoContactoEnum.BU;
        }

    }

    [Table("ContactoCliente")]
    public class ContactoCliente : Persona
    {
        public int IdEndUser { get; set; }
        public int IdVendor { get; set; }
        [Computed]
        public int BUCliente { get; set; }

        public ContactoCliente()
        {
            BUCliente = (int)TipoContactoEnum.Cliente;
        }
    }
}
