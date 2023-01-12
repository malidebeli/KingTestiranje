using TicketOffice.Core.Models;

namespace TicketOffice.Api.Resources
{
    public class SaveOrderResource
    {     
        public string CustomerId { get; set; }
        public ICollection<SaveTicketResource> Tickets { get; set; }
    }
}
