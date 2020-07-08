using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.Server.Domain.Repositories.Abstract
{
    public interface IProductRepository
    {
        public IQueryable<Product> GetProducts();  // все продукты
        public Product GetProduct(int id);   //  продукт с конкретным айди
        public void SaveProduct(Product product);   //  сохранение продукта
        public void DeleteProduct(int id);     // удаление продукта по айди
    }
}
