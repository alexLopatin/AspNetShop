using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetShop.Shared.ModelView
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        public string Description { get; set; }
        public string Banner { get; set; }
    }
}
