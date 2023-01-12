using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Core.Models;

namespace TicketOffice.Core.Services
{
    public interface ITicketService
    {
        Task<Ticket> CreateTicket(Ticket ticket);
        Task<Ticket> GetTicketById(string ticketId);
        Task UpdateTicket(Ticket ticketToBeUpdated, Ticket ticket);
        Task DeleteTicket(Ticket ticket);
    }
}
