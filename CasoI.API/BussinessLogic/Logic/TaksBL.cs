using CasoI.API.BussinessLogic.Interfaces;
using CasoI.API.Data;
using CasoI.API.DataAccess.Interfaces;
using CasoI.API.DTOS;
using CasoI.API.DTOS.CreateTask_DTO;
using CasoI.API.Models.BoardViewModel;
using System;
using System.Data.Entity;


namespace CasoI.API.BussinessLogic.Logic
{
    public class TaskBL : I_TaskBL
    {

        private readonly ObjContexto _db;


        private readonly I_TaskDA _Task;

        public TaskBL(I_TaskDA task) => _Task = task;


        public async Task<List<CreateTaskDTO>> GetAllTasks()
        {
            var list = await _Task.GetAllTasks();
            return list.Select(task => new CreateTaskDTO(
                task.Id,
                task.Nombre,
                task.Descripcion,
                task.Estado
            )).ToList();
        }

        public async Task<CreateTaskDTO?> GetTaskById(int id)
        {
            var task = await _Task.GetTaskById(id);
            return task is null ? null : new CreateTaskDTO(
                task.Id,
                task.Nombre,
                task.Descripcion,
                task.Estado
            );
        }

        public async Task<CreateTaskDTO> CreateTask(CreateTaskDTO dto)
        {
            var newTask = new BoardViewModel
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Estado = UserStoryStatus.Backlog
            };
            await _Task.AddAsync(newTask);
            return new CreateTaskDTO(
                newTask.Id,
                newTask.Nombre,
                newTask.Descripcion,
                newTask.Estado
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