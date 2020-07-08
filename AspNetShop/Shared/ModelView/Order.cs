using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetShop.Shared.ModelView
{
    public class Order
    {
        public int Id { get; set; }
        public IEnumerable<ProductOrder> Products { get; set; }
        public IEnumerable<string> States { get; set; }
        public int AllCountOfStates { get; set; }
        public double DeliveryPrice { get; set; }
        public DateTime LastStateChangeTime { get; set; }
        public string DeliveryType { get; set; }
        public string Address { get; set; }
    }
}
