using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Server.Domain.Entitys;

namespace AspNetShop.Server.Domain.Repositories.Abstract
{
    public interface IProductRepository
    {
        public IQueryable<Product> GetProducts();  // все продукты
        public Product GetProduct(Guid id);   //  продукт с конкретным айди
        public void SaveProduct(Product product);   //  сохранение продукта
        public void DeleteProduct(Guid id);     // удаление продукта по айди
    }
}
