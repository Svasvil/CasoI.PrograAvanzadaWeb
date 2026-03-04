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
        public async Task<ActionResult<List<CreateTaskDTO>>> GetAllTasks()
        {
            try
            {
                var result = await _TaskBL.GetAllTasks();
                if (result == null) return Ok(new List<CreateTaskDTO>());
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Esto detendrá la API aquí y podrás ver el error real en 'ex'
                return StatusCode(500, ex.Message);
            }
        }

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