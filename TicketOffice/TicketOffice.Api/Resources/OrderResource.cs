using TicketOffice.Core.Models;

namespace TicketOffice.Api.Resources
{
    public class OrderResource
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Timestamp { get; set; }
        public ICollection<TicketResource> Tickets { get; set; }
    }
}
