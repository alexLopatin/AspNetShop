using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Server.Data;
using AspNetShop.Server.Domain.Entities;
using AspNetShop.Server.Domain.Repositories.Abstract;
using AspNetShop.Shared.ModelView;
using Microsoft.EntityFrameworkCore;

namespace AspNetShop.Server.Domain.Repositories.EntityFramework
{
	public class EFProductRepository : IProductRepository
	{
		private AppDbContext context;
		public EFProductRepository(AppDbContext context)
		{
			this.context = context;
		}

		public IQueryable<ProductEntity> GetProducts()
		{
			return context.Product;
		}

		public List<Product> GetProductsModel()
		{
			var list = new List<Product>();
            foreach (var productEntity in context.Product)
            {
                list.Add(productEntity.ToProduct());
            }

            return list;
        }

		public ProductEntity GetProduct(int id)
		{
			return context.Product.FirstOrDefault(product => product.Id == id);
		}

		public void SaveProduct(ProductEntity product)
		{
			if (product.Id == default)
			{
				context.Entry(product).State = EntityState.Added;
			}
			else
			{
				context.Entry(product).State = EntityState.Modified;
			}

			context.SaveChanges();
		}

		public void DeleteProduct(int id)
		{
			context.Product.Remove(new ProductEntity()
			{
				Id = id
			});

			context.SaveChanges();
		}
	}
}
