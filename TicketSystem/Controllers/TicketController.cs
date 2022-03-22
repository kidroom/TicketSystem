using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Service;

namespace TicketSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicketService ticketService;
        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        public IActionResult TicketList()
        {
            return View();
        }

        [HttpGet("List")]
        public async Task<IList<TicketList>> TicketListAsync()
        {
            var result = await ticketService.GetListAsync();
            return result;
        }

        [HttpPost("Save")]
        public IActionResult SaveTicketAsync(TicketList req)
        {
            ticketService.SaveTaskList(req);

            return Ok();
        }
    }
}
