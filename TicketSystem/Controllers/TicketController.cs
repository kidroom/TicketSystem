using Microsoft.AspNetCore.Mvc;

namespace TicketSystem.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult TicketList()
        {
            return View();
        }
    }
}
