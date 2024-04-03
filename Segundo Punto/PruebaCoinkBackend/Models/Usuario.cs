namespace PruebaCoinkBackend.Models
{
    public class Usuario
    {
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public int IdPais { get; set; }
        public int IdDepartamento { get; set; }
        public int IdMunicipio { get; set; }
    }
}
