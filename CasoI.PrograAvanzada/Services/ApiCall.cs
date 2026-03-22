using CasoI.PrograAvanzada.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CasoI.PrograAvanzada.Services
{
    public class ApiCall : I_ApiCall
    {
        private readonly HttpClient _Conexion;
        
        public ApiCall(HttpClient conexion) => _Conexion = conexion;

        public async Task<List<TaskModelView>> GetAllAsync(CancellationToken canc = default)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() } 
            };

            return await _Conexion.GetFromJsonAsync<List<TaskModelView>>("api/Task", options, canc)
                   ?? new List<TaskModelView>();
        }
        public async Task CreateTaskAyncs(string Nombre, string Descripcion, int userId, int dificultad, CancellationToken cancellation = default)
        {
            var response = await _Conexion.PostAsJsonAsync("api/Task", new
            {
                Nombre = Nombre,
                Descripcion = Descripcion,
                UserId = userId,    
                Dificultad = dificultad
            }, cancellation);

            response.EnsureSuccessStatusCode(); 
        }

        public async Task NextTaskAsync(int id, CancellationToken cancellation = default)
        {
            await _Conexion.PostAsync($"api/Task/{id}/advance", null, cancellation);
        }
    }
}
