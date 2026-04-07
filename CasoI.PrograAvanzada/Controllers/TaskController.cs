using CasoI.PrograAvanzada.Services;
using CasoI.PrograAvanzada.Services.USERS;
using Microsoft.AspNetCore.Mvc;

namespace CasoI.PrograAvanzada.Controllers
{
    public class TaskController : Controller
    {
        private readonly I_ApiCall TheCall;
        private readonly I_UsersApiCall _usersCall;

        public TaskController(I_ApiCall theCall, I_UsersApiCall usersCall)
        {
            TheCall = theCall;
            _usersCall = usersCall;
        }

        public async Task<IActionResult> Index()
        {
            var list = await TheCall.GetAllAsync();

            var users = await _usersCall.GetAllAsync();
            ViewBag.Users = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(users, "Id", "Nombre");

            ViewData["ColorBacklog"] = "bg-secondary";
            ViewData["ColorToDo"] = "bg-primary";
            ViewData["ColorInProgress"] = "bg-warning";
            ViewData["ColorDone"] = "bg-success";

            return View(list.OrderBy(t => t.id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask(string Nombre, string Descripcion, int UserId, CancellationToken cancellation)
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Descripcion))
                return BadRequest("Campos Requeridos");

            var taskCreada = await TheCall.CreateTaskAyncs(Nombre, Descripcion, UserId, 0, cancellation);

            if (taskCreada.Dificultad > 7) 
            {
                TempData["AltaDificultad"] = $"La tarea '{Nombre}' tiene una estimación alta: {taskCreada.Dificultad}";
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> NextTask(int id)
        {
            await TheCall.NextTaskAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}