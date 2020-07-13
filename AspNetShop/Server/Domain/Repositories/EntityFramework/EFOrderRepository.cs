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

        public void SaveOrder(OrderEntity order)
        {
            context.Order.Add(order);

            if (order.Id == default)
            {
                context.Entry(order).State = EntityState.Added;
            }
            else
            {
                context.Entry(order).State = EntityState.Modified;
            }

            context.SaveChanges();
        }
    }
}
