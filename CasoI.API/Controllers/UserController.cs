using CasoI.API.BussinessLogic.Interfaces.USERS;
using CasoI.API.DTOS.CreateUserDTO;
using Microsoft.AspNetCore.Mvc;


namespace CasoI.API.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UserController : ControllerBase //
    {
        private readonly I_UsersBL _usersBL;
        public UserController(I_UsersBL usersBL) => _usersBL = usersBL;

        [HttpGet]
        public async Task<ActionResult<List<CreateUserDTO>>> GetAll()
        {
            var result = await _usersBL.GetAllUsers();
            return Ok(result ?? new List<CreateUserDTO>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _usersBL.GetUserById(id);
            if (task is null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateUserDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _usersBL.CreateUser(model);
            return Ok();
        }
    }
}