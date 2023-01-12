namespace TicketOffice.Api.Resources
{
    public class SaveTicketResource
    {
        public string TicketId { get; set; }       
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public decimal Price { get; set; }
    }
}
