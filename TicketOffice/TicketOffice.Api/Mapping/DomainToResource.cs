using AutoMapper;
using TicketOffice.Api.Resources;
using TicketOffice.Core.Models;

namespace TicketOffice.Api.Mapping
{
    public class DomainToResource:Profile
    {
        public DomainToResource() {
            CreateMap<Order, OrderResource>();
            CreateMap<Ticket, TicketResource>()
                .ForMember(t => t.MoneyValue, tr => tr.MapFrom(x => String.Format("{0} EUR", x.Price.ToString())));
        }
    }
}
