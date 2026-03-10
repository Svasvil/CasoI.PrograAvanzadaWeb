using CasoI.PrograAvanzada.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasoI.PrograAvanzada.Controllers
{
    public class TaskController : Controller
    {
        private readonly I_ApiCall TheCall;

        public TaskController(I_ApiCall theCall) => TheCall = theCall;

        public async Task<IActionResult> Index()
        {
            var list = await TheCall.GetAllAsync();

            ViewData["ColorBacklog"] = "bg-secondary";
            ViewData["ColorToDo"] = "bg-primary";
            ViewData["ColorInProgress"] = "bg-warning";
            ViewData["ColorDone"] = "bg-success";

            return View(list.OrderBy(t => t.id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(string Nombre, string Descripcion, string AsignadoA, CancellationToken cancellation)
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Descripcion))
                return BadRequest("Campos Requeridos");

            await TheCall.CreateTaskAyncs(Nombre, Descripcion, AsignadoA, 0, cancellation);
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