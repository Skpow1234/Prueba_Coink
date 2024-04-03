using Npgsql;
using PruebaCoinkBackend.Dto;
using PruebaCoinkBackend.Repository.Interfaces;

namespace PruebaCoinkBackend.Repository
{
     public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuration;

        public UsuarioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> RegistrarUsuario(UsuarioDTO usuarioDTO)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                await conn.OpenAsync();

                // Validaciones de existencia para país, departamento y municipio.
                if (!(await ExisteEnTabla("pais", "id", usuarioDTO.IdPais, conn) &&
                      await ExisteEnTabla("departamento", "id", usuarioDTO.IdDepartamento, conn) &&
                      await ExisteEnTabla("municipio", "id", usuarioDTO.IdMunicipio, conn)))
                {
                    throw new Exception("Uno o más IDs de ubicación no son válidos.");
                }

                // Si las validaciones son exitosas, se procede a insertar el usuario.
                await using (var cmd = new NpgsqlCommand("CALL insertar_usuario(@nombre, @telefono, @direccion, @id_pais, @id_departamento, @id_municipio)", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", usuarioDTO.Nombre);
                    cmd.Parameters.AddWithValue("@telefono", usuarioDTO.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", usuarioDTO.Direccion ?? string.Empty); // Asumiendo que la dirección puede ser opcional.
                    cmd.Parameters.AddWithValue("@id_pais", usuarioDTO.IdPais);
                    cmd.Parameters.AddWithValue("@id_departamento", usuarioDTO.IdDepartamento);
                    cmd.Parameters.AddWithValue("@id_municipio", usuarioDTO.IdMunicipio);

                    await cmd.ExecuteNonQueryAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                // Aquí deberías manejar la excepción de manera adecuada, por ejemplo, logueando el error.
                Console.WriteLine($"Error al registrar usuario: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> ExisteEnTabla(string tabla, string columna, int id, NpgsqlConnection conn)
        {
            var cmd = new NpgsqlCommand($"SELECT EXISTS (SELECT 1 FROM {tabla} WHERE {columna} = @id)", conn);
            cmd.Parameters.AddWithValue("@id", id);
            return (bool)await cmd.ExecuteScalarAsync();
        }
    }
}
