using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IQueryable<Product> GetProducts()
        {
            return context.Products;
        }

        public Product GetProduct(int id)
        {
            return context.Products.FirstOrDefault(product => product.Id == id);
        }

        public void SaveProduct(Product product)
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
            context.Products.Remove(new Product()
            {
                Id = id
            });

            context.SaveChanges();
        }
    }
}
