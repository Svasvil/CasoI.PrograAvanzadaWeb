using CasoI.API.BussinessLogic.Interfaces;
using CasoI.API.DTOS.CreateTask_DTO;
using Microsoft.AspNetCore.Mvc;

namespace CasoI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly I_TaskBL _TaskBL;
        public TaskController(I_TaskBL TaskBL) => _TaskBL = TaskBL;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _TaskBL.GetAllTasks();
            return Ok(result ?? new List<CreateTaskDTO>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _TaskBL.GetTaskById(id);
            if (task is null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _TaskBL.CreateTask(model);

            return Ok(result);
        }

        [HttpPost("{id}/advance")]
        public async Task<IActionResult> AdvanceState(int id)
        {
            var ok = await _TaskBL.AdvanceStateAsync(id);
            if (!ok) return BadRequest();
            return Ok();
        }
    }
}