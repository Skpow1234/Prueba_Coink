using PruebaCoinkBackend.Dto;
using System.Threading.Tasks;

namespace PruebaCoinkBackend.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> RegistrarUsuario(UsuarioDTO usuarioDTO);
    }
}
