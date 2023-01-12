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
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        private TicketOfficeDbContext Context
        {
            get
            {
                return (base.Context as TicketOfficeDbContext);
            }
        }

        public TicketRepository(TicketOfficeDbContext hContext) :
        base(hContext)
        {

        }
    }
}
