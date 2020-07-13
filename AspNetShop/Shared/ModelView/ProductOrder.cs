using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetShop.Shared.ModelView
{
    public class ProductOrder
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}