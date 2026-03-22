using CasoI.PrograAvanzada.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CasoI.PrograAvanzada.Services.USERS
{
    public class UserApiCall : I_UsersApiCall 
    {
        public readonly HttpClient _Conexion;
        public UserApiCall(HttpClient conexion) => _Conexion = conexion;

        public async Task<List<UsersModelView>> GetAllAsync(CancellationToken canc = default)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            };
            return await _Conexion.GetFromJsonAsync<List<UsersModelView>>("api/Users", options, canc)
                   ?? new List<UsersModelView>();
        }
        public async Task CreateUserAyncs(string Nombre, string Apellidos, string email,
            int PokeApiAvatar, CancellationToken cancellation = default)
        {
            var nuevoUsuario = new
            {
                Nombre = Nombre,
                Apellidos = Apellidos,
                Email = email,
                PokeApiAvatar = PokeApiAvatar 
            };
            await _Conexion.PostAsJsonAsync("api/Users", nuevoUsuario, cancellation);
        }
    }
}