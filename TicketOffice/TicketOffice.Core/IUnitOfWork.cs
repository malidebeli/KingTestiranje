using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Core.Repositories;

namespace TicketOffice.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Order { get; }
        ITicketRepository Ticket { get; }
        Task<int> CommitAsync();
    }
}
