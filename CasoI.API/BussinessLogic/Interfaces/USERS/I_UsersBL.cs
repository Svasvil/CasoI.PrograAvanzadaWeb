using CasoI.API.DTOS.CreateUserDTO;
using Microsoft.SqlServer.Management.Dmf;

namespace CasoI.API.BussinessLogic.Interfaces.USERS
{
    public interface I_UsersBL
    {
        Task<List<CreateUserDTO>> GetAllUsers();
        Task<CreateUserDTO?> GetUserById(int id);
                Task<CreateUserDTO> CreateUser(CreateUserDTO user);


    }
}
