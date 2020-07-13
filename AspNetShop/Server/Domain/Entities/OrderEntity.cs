using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Shared.ModelView;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspNetShop.Server.Domain.Entities
{
	public class OrderEntity
	{
		public int Id { get; set; }
		public int DeliveryType { get; set; }
		public int DeliveryTypeOption { get; set; }
		public string Address { get; set; }
		public int PaymentType { get; set; }
		public int OrderNumber { get; set; }
		public List<OrderProductEntity> OrderProduct { get; set; }

		public OrderEntity()
		{
			OrderProduct = new List<OrderProductEntity>();
		}
	}
}
