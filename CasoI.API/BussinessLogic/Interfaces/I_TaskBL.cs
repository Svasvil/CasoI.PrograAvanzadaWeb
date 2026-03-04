using CasoI.API.Models.BoardViewModel;
using CasoI.API.DTOS;
using CasoI.API.DTOS.CreateTask_DTO;

namespace CasoI.API.BussinessLogic.Interfaces
{
    public interface I_TaskBL
    {
        Task<List<CreateTaskDTO>> GetAllTasks(); 
        Task<CreateTaskDTO?> GetTaskById(int id);
            Task<CreateTaskDTO> CreateTask(CreateTaskDTO task);
            Task<bool> AdvanceStateAsync(int id);
    }
}
