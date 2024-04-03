using Microsoft.AspNetCore.Mvc;
using PruebaCoinkBackend.Dto;
using PruebaCoinkBackend.Repository.Interfaces;

namespace PruebaCoinkBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _usuarioRepository.RegistrarUsuario(usuarioDTO);
            if (result)
            {
                return Ok("Usuario registrado con éxito.");
            }
            else
            {
                return StatusCode(500, "Error al registrar el usuario.");
            }
        }
    }
}
