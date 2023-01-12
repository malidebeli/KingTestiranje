using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Core;
using TicketOffice.Core.Repositories;
using TicketOffice.Data.Repositories;

namespace TicketOffice.Data
{
    public  class UnitOfWork: IUnitOfWork
    {
        private readonly TicketOfficeDbContext _context;
        private TicketRepository _ticketRepository;
        private OrderRepository _orderRepository;

        public UnitOfWork(TicketOfficeDbContext context)
        {
            this._context = context;
        }

        public ITicketRepository Ticket => _ticketRepository = _ticketRepository ?? new TicketRepository(_context);

        public IOrderRepository Order => _orderRepository = _orderRepository ?? new OrderRepository(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
