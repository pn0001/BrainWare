using System;
using System.Collections.Generic;
using System.Web.Http;
using Entities;
using Entities.Models;
using Repositories;
using Repositories.DAL;


namespace Web.Controllers
{   
    
    public class OrderController : ApiController
    {
        private IOrderRepository _orderRepository;

        public OrderController()
        {
            _orderRepository = new OrderRepository(new OrderDBContext());
        }

        [HttpGet]
        public IEnumerable<OrderDto> GetOrders(int id = 1)
        {
            var result = _orderRepository.GetOrdersForCompany(id);
            return result;    
        }
    }
}
