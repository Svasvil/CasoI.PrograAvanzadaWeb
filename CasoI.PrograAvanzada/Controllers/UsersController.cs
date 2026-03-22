using CasoI.PrograAvanzada.Services.USERS;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CasoI.PrograAvanzada.Controllers
{
    public class UsersController : Controller
    {

        private readonly I_UsersApiCall TheCall;
        public UsersController(I_UsersApiCall theCall) => TheCall = theCall;


        public async Task<IActionResult> Index()
        {
            var userList = await TheCall.GetAllAsync();
            return View(userList.OrderBy(t => t.Id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(string Nombre, string Apellidos, string email)
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Apellidos) || string.IsNullOrWhiteSpace(email))
                return BadRequest("Campos Requeridos");

            await TheCall.CreateUserAyncs(Nombre, Apellidos, email, 0);
            return RedirectToAction(nameof(Index));
        }
    }
}
