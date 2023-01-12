using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Core.Models;
using TicketOffice.Core.Repositories;

namespace TicketOffice.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private TicketOfficeDbContext Context
        {
            get
            {
                return (base.Context as TicketOfficeDbContext);
            }
        }

        public OrderRepository(TicketOfficeDbContext hContext) :
        base(hContext)
        {

        }

        public async Task<Order> GetOrderByIdWithTickets(int id)
        {
            return await Context.Order
                 .Include(x => x.Tickets)
                 .SingleOrDefaultAsync(x => x.OrderId == id);
        }
    }
}
