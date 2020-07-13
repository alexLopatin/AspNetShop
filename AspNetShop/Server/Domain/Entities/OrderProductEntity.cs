using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.Server.Domain.Entities
{
    public class OrderProductEntity
    {
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }
        
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
