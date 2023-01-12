using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Core;
using TicketOffice.Core.Models;
using TicketOffice.Core.Services;

namespace TicketOffice.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;          
        }

        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            await _unitOfWork.Ticket
            .AddAsync(ticket);
            await _unitOfWork.CommitAsync();

            return ticket;
        }

        public async Task DeleteTicket(Ticket ticket)
        {
            _unitOfWork.Ticket.Remove(ticket);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Ticket> GetTicketById(string ticketId)
        {
            return await _unitOfWork.Ticket.GetByIdAsync(ticketId);
        }

        public async Task UpdateTicket(Ticket ticketToBeUpdated, Ticket ticket)
        {
            ticketToBeUpdated.FromLocation = ticket.FromLocation;
            ticketToBeUpdated.ToLocation = ticket.ToLocation;
            ticketToBeUpdated.Price = ticket.Price;
            ticketToBeUpdated.Timestamp = ticket.Timestamp;
            await _unitOfWork.CommitAsync();
        }
    }
}
