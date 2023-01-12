using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Core.Models;

namespace TicketOffice.Core.Repositories
{
    public interface ITicketRepository: IRepository<Ticket>
    {
    }
}
