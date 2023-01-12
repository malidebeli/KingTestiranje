namespace TicketOffice.Api.Resources
{
    public class TicketResource
    {
        public string TicketId { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public decimal Price { get; set; }
        public string MoneyValue { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
