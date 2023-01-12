using System.Net.Sockets;
using TicketOffice.Core;
using TicketOffice.Core.Models;
using TicketOffice.Core.Services;

namespace TicketOffice.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await _unitOfWork.Order.AddAsync(order);
            await _unitOfWork.CommitAsync();
            return order;
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _unitOfWork.Order.GetByIdAsync(orderId);
        }


        public async Task<Order> GetOrderByIdWithTickets(int orderId)
        {
            return await _unitOfWork.Order.GetOrderByIdWithTickets(orderId);
        }


        public async Task UpdateOrder(Order orderToBeUpdated, Order order)
        {
            orderToBeUpdated.Tickets = order.Tickets;
            orderToBeUpdated.Timestamp = order.Timestamp;
            await _unitOfWork.CommitAsync();
        }

        
    }
}