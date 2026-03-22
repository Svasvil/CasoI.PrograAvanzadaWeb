using CasoI.PrograAvanzada.Models;

namespace CasoI.PrograAvanzada.Services.USERS
{
    public interface I_UsersApiCall
    {
        Task<List<UsersModelView>> GetAllAsync(CancellationToken canc = default);
        Task CreateUserAyncs(string Nombre, string Apellidos, string email, int PokeApiAvatar, CancellationToken cancellation = default);
    }
}
