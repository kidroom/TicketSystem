using Repository;
using Repository.Models;
using Repository.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models.Responses;

namespace TicketSystem.Service
{
    public interface ITicketService
    {
        Task<IList<TicketList>> GetListAsync();
        void SaveTaskList(TicketList req);
    }
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }

        public async Task<IList<TicketList>> GetListAsync()
        {
            var ticket = await ticketRepository.ListAsync();
            return ticket;
        }

        public void SaveTaskList(TicketList req)
        {
            ticketRepository.Update(req);
            ticketRepository.SaveChanges();
        }
    }
}
