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
            return View(list.OrderBy(Task => Task.id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(string Nombre, string Descripcion, string AsignadoA,int Dificultad, CancellationToken cancellation)
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Descripcion))
                return BadRequest("Campos Requeridos");

            await TheCall.CreateTaskAyncs(Nombre, Descripcion, AsignadoA, Dificultad);
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
