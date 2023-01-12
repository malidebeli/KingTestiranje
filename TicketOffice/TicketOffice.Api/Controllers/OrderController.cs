using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketOffice.Api.Resources;
using TicketOffice.Core.Models;
using TicketOffice.Core.Services;

namespace TicketOffice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        IMapper _mapper;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IOrderService orderService, IMapper mapper, ILogger<OrderController> logger)
        {
            _orderService = orderService;            
            _mapper = mapper;
            _logger = logger;        
        }



        [HttpPost("")]
        public async Task<ActionResult<OrderResource>> CreateOrder([FromBody] SaveOrderResource saveOrderResource)
        {       
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            var orderToCreate = _mapper.Map<SaveOrderResource, Order>(saveOrderResource);

            var newOrder = await _orderService.CreateOrder(orderToCreate);

            var order = await _orderService.GetOrderById(newOrder.OrderId);

            var orderResource = _mapper.Map<Order, OrderResource>(order);

            return Ok(orderResource);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<OrderResource>> GetById([FromRoute] int id)
        {        
            var order = await _orderService.GetOrderByIdWithTickets(id);
            var orderResource = _mapper.Map<Order, OrderResource>(order);
            return Ok(orderResource);
        }



    }
}
