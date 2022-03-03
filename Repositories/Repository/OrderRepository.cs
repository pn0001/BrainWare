using Entities.Models;
using Repositories.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDBContext _context;
        public OrderRepository()
        {
            _context = new OrderDBContext();
        }

        public OrderRepository(OrderDBContext context)
        {
            _context = context;
        }


        public IEnumerable<OrderDto> GetOrdersForCompany(int CompanyId)
        {
          
            var values =
                    from company in _context.Companies.AsEnumerable()
                    join order in _context.Orders.AsEnumerable() on company.company_id equals order.company_id
                    select new OrderDto
                    {
                        CompanyName = company.name,
                        Description = order.description,
                        OrderId = order.order_id,
                        OrderProducts = new List<OrderProductDto>()
                    };

            var values2 =
                   from op in _context.orderproducts.AsEnumerable()
                   join product in _context.Products.AsEnumerable() on op.product_id equals product.product_id
                   select new OrderProductDto
                   {
                       OrderId = op.order_id,
                       ProductId = op.product_id,
                       Price = op.price ?? 0,
                       Quantity = op.quantity,
                       Product = new ProductDto()
                       {
                           Name = product.name,
                           Price = product.price ??0
                       }
                   };

            var xx = values.ToList();

            xx.ForEach(order =>
            {
                values2.ToList().ForEach(orderproduct =>
                {
                    if (orderproduct.OrderId == order.OrderId)
                    {
                        order.OrderProducts.Add(orderproduct);
                        order.OrderTotal = order.OrderTotal + (orderproduct.Price * orderproduct.Quantity);
                    }
                });
            });


            return xx; 


        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
