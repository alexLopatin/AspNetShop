using AspNetShop.Server.Domain.Entities;
using AspNetShop.Shared.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetShop.Server.Domain.Repositories.Abstract
{
    public interface IOrderRepository
    {
        public void SaveOrder(OrderEntity order);
    }
}
