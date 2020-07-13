using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Server.Domain.Entities;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.Server.Domain.Repositories.Abstract
{
    public interface IProductRepository
    {
        public IQueryable<ProductEntity> GetProducts();  // все продукты
        public List<Product> GetProductsModel();
        public ProductEntity GetProduct(int id);   //  продукт с конкретным айди
        public void SaveProduct(ProductEntity product);   //  сохранение продукта
        public void DeleteProduct(int id);     // удаление продукта по айди
    }
}
