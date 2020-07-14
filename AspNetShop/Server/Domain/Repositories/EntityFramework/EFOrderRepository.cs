using AspNetShop.Server.Domain.Entities;
using AspNetShop.Server.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetShop.Server.Domain.Repositories.EntityFramework
{
    public class EFOrderRepository : IOrderRepository
    {
        private AppDbContext context;

        public EFOrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void SaveOrder(OrderEntity order, Shared.Form.Order orderForm)
        {
            //context.Order.Add(order);
            if (order.Id == default)
            {
                context.Entry(order).State = EntityState.Added;
            }
            else
            {
                context.Entry(order).State = EntityState.Modified;
            }
            context.SaveChanges();

            foreach (var prod in orderForm.Products)
            {
                order.OrderProduct.Add(new OrderProductEntity
                {
                    OrderId = order.Id,
                    ProductId = prod.ProductId,
                    CountProduct = prod.Count
                });
            }


            context.SaveChanges();


        }

        public IEnumerable<OrderEntity> GetUserOrders(Guid userId)
        {
            var res = context.Order.Where(entity => entity.UserId == userId)
                .Include(o => o.OrderProduct)
                .ThenInclude(op => op.Product).ToList();

            return res;
        }
    }
}
