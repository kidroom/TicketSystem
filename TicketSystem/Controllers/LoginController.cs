using Microsoft.AspNetCore.Mvc;

namespace TicketSystem.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
