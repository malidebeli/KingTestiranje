using TicketOffice.Core.Models;

namespace TicketOffice.Core.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order order);
        Task<Order> GetOrderById(int orderId);
        Task<Order> GetOrderByIdWithTickets(int orderId);
        Task UpdateOrder(Order orderToBeUpdated, Order order);
       
    }
}
