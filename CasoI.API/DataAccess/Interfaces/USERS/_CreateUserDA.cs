using CasoI.API.Models;

namespace CasoI.API.DataAccess.Interfaces.USERS
{
    public interface _CreateUserDA
    {
        Task AddAsync(UsersModel user);
        Task<List<UsersModel>> GetAllUsers();
        Task<UsersModel> GetUserById(int id);
        
    }
}
