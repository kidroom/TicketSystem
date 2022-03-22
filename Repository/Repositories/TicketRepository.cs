using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public interface ITicketRepository: IGenericRepository<TicketList> { }
    public class TicketRepository : GenericRepository<TicketList>, ITicketRepository
    {
        private readonly MsDbContext dbContext;
        public TicketRepository(MsDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
