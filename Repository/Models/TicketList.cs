﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class TicketList
    {
        public int TicketId { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

    }
}
