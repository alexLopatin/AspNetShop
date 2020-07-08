using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetShop.Shared.ModelView
{
    public class ProductList
    {
        public IEnumerable<Product> Products { get; set; }
        public int CountOfPages { get; set; } = 1;
    }
}