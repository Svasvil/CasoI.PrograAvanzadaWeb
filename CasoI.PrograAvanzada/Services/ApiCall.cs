using CasoI.PrograAvanzada.Models;
using System.Net.Http.Json;
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

        public async Task<TaskModelView> CreateTaskAyncs(string Nombre, string Descripcion, int userId, int dificultad, CancellationToken cancellation = default)
        {
            var response = await _Conexion.PostAsJsonAsync("api/Task", new
            {
                Nombre = Nombre,
                Descripcion = Descripcion,
                UserId = userId,
                Dificultad = dificultad
            }, cancellation);

            response.EnsureSuccessStatusCode();

            // CONFIGURACIÓN DE OPCIONES: Agregamos el convertidor de Enums
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() } // Esto arregla el error del enum 'Estado'
            };

            // LEER LA RESPUESTA: Ahora sí podrá convertir "Backlog" al enum UserStoryStatus
            var resultado = await response.Content.ReadFromJsonAsync<TaskModelView>(options, cancellation);

            return resultado ?? new TaskModelView();
        }
        public async Task NextTaskAsync(int id, CancellationToken cancellation = default)
        {
            await _Conexion.PostAsync($"api/Task/{id}/advance", null, cancellation);
        }
    }
}