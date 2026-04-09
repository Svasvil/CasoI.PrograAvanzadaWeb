using CasoI.API.BussinessLogic.Interfaces;
using CasoI.API.BussinessLogic.Interfaces.Factory;
using CasoI.API.DataAccess.Interfaces;
using CasoI.API.DTOS.CreateTask_DTO;
using CasoI.API.Models.BoardViewModel;
using System.Net.Http.Json;

namespace CasoI.API.BussinessLogic.Logic
{
    public class TaskBL : I_TaskBL
    {
        private readonly I_TaskDA _Task;
        private readonly List<ITaskObserver> _observers = new();
        private readonly IBoardViewModelFactory _factory;


        public TaskBL(I_TaskDA task, IEnumerable<ITaskObserver> observers, IBoardViewModelFactory factory)
        {
            _Task = task;
            _observers.AddRange(observers);
            _factory = factory; // <--- ASIGNAR LA INSTANCIA
        }

        public async Task<CreateTaskDTO> CreateTask(CreateTaskDTO dto)
        {
            using var http = new HttpClient();
            var estimate = await http.GetFromJsonAsync<int>("http://localhost:5285/api/estimate");

            var newTask = _factory.Create(dto, estimate);

            await _Task.AddAsync(newTask);
            foreach (var observer in _observers)
                await observer.NotifyAsync(newTask);

            return new CreateTaskDTO(
                newTask.Id, newTask.Nombre, newTask.Descripcion,
                newTask.Estado, newTask.UserId, null, null, newTask.Dificultad
            );
        }

        public async Task<bool> AdvanceStateAsync(int id)
        {
            var task = await _Task.GetTaskById(id);
            if (task == null) return false;

            switch (task.Estado)
            {
                case UserStoryStatus.Backlog: task.Estado = UserStoryStatus.ToDo; break;
                case UserStoryStatus.ToDo: task.Estado = UserStoryStatus.InProgress; break;
                case UserStoryStatus.InProgress: task.Estado = UserStoryStatus.Done; break;
                default: return false;
            }

            await _Task.UpdateAsync(task);

            foreach (var observer in _observers)
            {
                await observer.NotifyAsync(task);
            }

            return true;
        }

        public async Task<List<CreateTaskDTO>> GetAllTasks()
        {
            var list = await _Task.GetAllTasks();
            return list.Select(t => new CreateTaskDTO(t.Id, t.Nombre, t.Descripcion, t.Estado, t.UserId, t.AsignadoA?.Nombre, null, t.Dificultad)).ToList();
        }

        public async Task<CreateTaskDTO?> GetTaskById(int id)
        {
            var t = await _Task.GetTaskById(id);
            return t == null ? null : new CreateTaskDTO(t.Id, t.Nombre, t.Descripcion, t.Estado, t.UserId, t.AsignadoA?.Nombre, null, t.Dificultad);
        }
    }
}