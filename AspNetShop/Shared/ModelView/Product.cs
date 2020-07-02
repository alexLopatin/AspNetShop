using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetShop.Shared.ModelView
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public DateTime TimeAdded { get; set; }
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
        public double Rating { get; set; }
    }
}
