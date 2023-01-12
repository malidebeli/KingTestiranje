using AutoMapper;
using TicketOffice.Api.Resources;
using TicketOffice.Core.Models;

namespace TicketOffice.Api.Mapping
{
    public class ResourceToDomain: Profile
    {
        public ResourceToDomain()
        {
            CreateMap<SaveOrderResource, Order>();
            CreateMap<SaveTicketResource, Ticket>();


        }
    }
}
