using CasoI.API.BussinessLogic.Interfaces.USERS;
using CasoI.API.Data;
using CasoI.API.DataAccess.Interfaces.USERS;
using CasoI.API.DTOS.CreateUserDTO;
using CasoI.API.Models;

namespace CasoI.API.BussinessLogic.Logic.USERS
{
    public class UsersBL : I_UsersBL
    {
        private readonly ObjContexto _db;
        private readonly _CreateUserDA _user;

        //constructor
        public UsersBL(_CreateUserDA user) => _user = user;

        //get users
        public async Task<List<CreateUserDTO>> GetAllUsers()
        {
            var list = await _user.GetAllUsers();
            return list.Select(user => new CreateUserDTO(
                user.Id,
                user.Nombre,
                user.Apellidos,
                user.email,
                user.PokeApiAvatar
            )).ToList();
        }
        //get yser by id 
        public async Task<CreateUserDTO?> GetUserById(int id)
        {
            var user = await _user.GetUserById(id);
            return user is null ? null : new CreateUserDTO(
                user.Id,
                user.Nombre,
                user.Apellidos,
                user.email,
                user.PokeApiAvatar
            );
                    }
        //addd user 
        public async Task<CreateUserDTO> CreateUser(CreateUserDTO dto)
        {
            using var http = new HttpClient();
            Random pokeID = new Random();
            var pokeUser = new UsersModel
            {
                Id= dto.Id,
                Nombre = dto.Nombre,
                Apellidos = dto.Apellidos,
                email = dto.email,
                PokeApiAvatar = pokeID.Next(1, 151)
            };
            await _user.AddAsync(pokeUser);
            return new CreateUserDTO(
                pokeUser.Id,
                pokeUser.Nombre,
                pokeUser.Apellidos,
                pokeUser.email,
                pokeUser.PokeApiAvatar
            );
        }

     
    }
}
