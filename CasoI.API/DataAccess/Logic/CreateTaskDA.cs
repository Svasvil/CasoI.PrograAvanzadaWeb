using CasoI.API.Models.BoardViewModel;
using CasoI.API.Data;
using CasoI.API.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CasoI.API.DataAccess.Logic
{
    public class CreateTaskDA : I_TaskDA
    {
        private  readonly ObjContexto _context;
        public CreateTaskDA(ObjContexto context) => _context = context;
        public async Task<List<BoardViewModel>> GetAllTasks() => await _context.Task
                .Include(t => t.AsignadoA) 
                .AsNoTracking()
                .ToListAsync();
        public async Task<BoardViewModel?> GetTaskById(int id) => await _context.Task.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

        public async Task AddAsync(BoardViewModel task)
        {
            _context.Task.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BoardViewModel task)
            {
            _context.Task.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
