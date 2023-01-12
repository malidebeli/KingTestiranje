using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketOffice.Core.Models
{
    public class Order
    {
        public Order()
        {
            Tickets = new Collection<Ticket>();
        }
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTime  Timestamp { get; set; }        
        public ICollection<Ticket> Tickets { get; set; }
    }
}
