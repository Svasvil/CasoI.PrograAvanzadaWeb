using CasoI.PrograAvanzada.Models;

public interface I_ApiCall
{
    Task<List<TaskModelView>> GetAllAsync(CancellationToken canc = default);

    Task<TaskModelView> CreateTaskAyncs(string Nombre, string Descripcion, int userId, int Dificultad, CancellationToken cancellation = default);

    Task NextTaskAsync(int id, CancellationToken cancellation = default);
}