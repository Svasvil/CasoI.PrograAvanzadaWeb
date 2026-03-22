using CasoI.API.BussinessLogic.Interfaces;
using CasoI.API.Data;
using CasoI.API.DataAccess.Interfaces;
using CasoI.API.DTOS.CreateTask_DTO;
using CasoI.API.Models.BoardViewModel;
using System.Linq;

namespace CasoI.API.BussinessLogic.Logic
{
    public class TaskBL : I_TaskBL
    {
        private readonly I_TaskDA _Task;
        public TaskBL(I_TaskDA task) => _Task = task;

        public async Task<List<CreateTaskDTO>> GetAllTasks()
        {
            var list = await _Task.GetAllTasks();
            return list.Select(task => new CreateTaskDTO(
                task.Id,
                task.Nombre,
                task.Descripcion,
                task.Estado,
                task.UserId,
                task.AsignadoA?.Nombre + " " + task.AsignadoA?.Apellidos,
                task.AsignadoA?.PokeApiAvatar.ToString(),
                task.Dificultad
            )).ToList();
        }

        public async Task<CreateTaskDTO?> GetTaskById(int id)
        {
            var task = await _Task.GetTaskById(id);
            return task is null ? null : new CreateTaskDTO(
                task.Id,
                task.Nombre,
                task.Descripcion,
                task.Estado,
                task.UserId,
                task.AsignadoA?.Nombre + " " + task.AsignadoA?.Apellidos, // ✅ Corregido
                task.AsignadoA?.PokeApiAvatar.ToString(),                  // ✅ Corregido
                task.Dificultad
            );
        }

        public async Task<CreateTaskDTO> CreateTask(CreateTaskDTO dto)
        {
            using var http = new HttpClient();
            var estimate = await http.GetFromJsonAsync<int>("http://localhost:5285/api/estimate");
            var newTask = new BoardViewModel
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Estado = UserStoryStatus.Backlog,
                UserId = dto.UserId,
                Dificultad = estimate
            };
            await _Task.AddAsync(newTask);
            return new CreateTaskDTO(
                newTask.Id,
                newTask.Nombre,
                newTask.Descripcion,
                newTask.Estado,
                newTask.UserId,
                null, // AsignadoA no disponible tras AddAsync
                null, // PokeApiAvatar no disponible tras AddAsync
                newTask.Dificultad
            );
        }

        public async Task<bool> AdvanceStateAsync(int id)
        {
            var task = await _Task.GetTaskById(id);
            if (task == null) return false;
            switch (task.Estado)
            {
                case UserStoryStatus.Backlog:
                    task.Estado = UserStoryStatus.ToDo;
                    break;
                case UserStoryStatus.ToDo:
                    task.Estado = UserStoryStatus.InProgress;
                    break;
                case UserStoryStatus.InProgress:
                    task.Estado = UserStoryStatus.Done;
                    break;
                case UserStoryStatus.Done:
                    return false;
            }
            await _Task.UpdateAsync(task);
            return true;
        }
    }
}