using CasoI.API.Data;
using CasoI.API.DataAccess.Interfaces.USERS;
using CasoI.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CasoI.API.DataAccess.Logic.USERS
{
    public class CreateUserDA : _CreateUserDA
    {
        private readonly ObjContexto _context;
        public CreateUserDA(ObjContexto context) => _context = context;

        public async Task AddAsync(UsersModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UsersModel>> GetAllUsers() =>
            await _context.Users.AsNoTracking().ToListAsync();

        public async Task<UsersModel?> GetUserById(int id) =>
            await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
    }
}