using CasoI.API.Data;
using CasoI.API.Models;
using CasoI.API.Models.BoardViewModel;
using Microsoft.EntityFrameworkCore;
namespace CasoI.API.DataAccess.Logic.USERS
{
    public class CreateUserDA
    {
        private readonly ObjContexto _context;
        public CreateUserDA(ObjContexto context) => _context = context;



        //create user
        public async Task AddAsync(UsersModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

        }
        //get all users th
        public async Task<List<UsersModel>> GetAllUsers() => await _context.Users.AsNoTracking().ToListAsync();
        //get unique id 
        public async Task<BoardViewModel?> GetUserById(int id) => await _context.Task.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        //update user 
        public async Task UpdateAsync(BoardViewModel task)
        {
            _context.Task.Update(task);
            await _context.SaveChangesAsync();
        }

    }
}
