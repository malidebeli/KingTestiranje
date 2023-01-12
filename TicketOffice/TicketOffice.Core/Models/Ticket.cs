using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketOffice.Core.Models
{
    public class Ticket
    {
        public string TicketId { get; set; }
        public int OrderId { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public decimal Price { get; set; }
        public DateTime Timestamp { get; set; }

        public Order Order { get; set; }

    }
}
