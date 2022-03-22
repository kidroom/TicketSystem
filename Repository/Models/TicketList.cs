using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class TicketList
    {
        public int TicketId { get; set; }

        public int Type { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public int Severity { get; set; }

        public int Priority { get; set; }

    }
}
