using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetShop.Shared.Form
{
    public class Order
    {
        public IEnumerable<ModelView.ProductOrder> Products { get; set; }
        public int DeliveryType { get; set; }
        public int DeliveryTypeOption { get; set; }
        public string Address { get; set; }
        public int PaymentType { get; set; }
    }
}
