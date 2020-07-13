using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.Server.Domain.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public DateTime TimeAdded { get; set; }
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public List<OrderProductEntity> OrderProduct { get; set; }

        public ProductEntity()
        {
            OrderProduct = new List<OrderProductEntity>();
        }

        public Product ToProduct()
        {
            return new Product()
            {
                Name = this.Name,
                Description = this.Description,
                CategoryId = this.CategoryId,
                Id = this.Id,
                NewPrice = this.NewPrice,
                OldPrice = this.OldPrice,
                Rating = this.Rating,
                Thumbnail = this.Thumbnail,
                TimeAdded = this.TimeAdded
            };
        }
    }
}
