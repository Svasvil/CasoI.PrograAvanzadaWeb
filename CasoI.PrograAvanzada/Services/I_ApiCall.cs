using CasoI.PrograAvanzada.Models;

namespace CasoI.PrograAvanzada.Services
{
    public interface I_ApiCall
    {
        Task<List<TaskModelView>> GetAllAsync(CancellationToken canc = default );
        Task CreateTaskAyncs(string Nombre, string Descripcion, int userId, int Dificultad, CancellationToken cancellation = default);
        Task NextTaskAsync(int id, CancellationToken cancellation = default);

    }
}
