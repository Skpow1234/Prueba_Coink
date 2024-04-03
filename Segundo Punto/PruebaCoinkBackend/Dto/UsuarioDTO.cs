using System.ComponentModel.DataAnnotations;

namespace PruebaCoinkBackend.Dto
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(255, ErrorMessage = "La longitud del nombre debe ser de hasta 255 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [StringLength(20, ErrorMessage = "La longitud del teléfono debe ser de hasta 20 caracteres.")]
        public string Telefono { get; set; }

        public string Direccion { get; set; } 

        [Required(ErrorMessage = "El ID del país es obligatorio.")]
        public int IdPais { get; set; }

        [Required(ErrorMessage = "El ID del departamento es obligatorio.")]
        public int IdDepartamento { get; set; }

        [Required(ErrorMessage = "El ID del municipio es obligatorio.")]
        public int IdMunicipio { get; set; }
    }
}
