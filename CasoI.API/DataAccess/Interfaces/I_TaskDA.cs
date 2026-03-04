using CasoI.API.Models.BoardViewModel;

namespace CasoI.API.DataAccess.Interfaces
{
    public interface I_TaskDA
    {
         Task<List<BoardViewModel>> GetAllTasks();
            Task<BoardViewModel?> GetTaskById(int id);
        Task AddAsync(BoardViewModel task);
        Task UpdateAsync(BoardViewModel task);
    }
}
