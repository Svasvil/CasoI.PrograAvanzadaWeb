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
        public async Task<List<CreateTaskDTO>> GetAllTasks()
            => await _TaskBL.GetAllTasks();

        [HttpGet("{id}")]
        public async Task<ActionResult<CreateTaskDTO>> GetTaskById(int id)
        {
            var task = await _TaskBL.GetTaskById(id);
            if (task is null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<CreateTaskDTO>> CreateTask(CreateTaskDTO dto)
        {
            var Task2 = await _TaskBL.CreateTask(dto);
            return CreatedAtAction(nameof(GetTaskById), new { id = Task2.id }, Task2);
        }

        [HttpPost("{id}/advance")]
        public async Task<IActionResult> AdvanceState(int id)
        {
            var ok = await _TaskBL.AdvanceStateAsync(id);
            if (!ok) return BadRequest();
            return NoContent();
        }
    }
}