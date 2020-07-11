using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetShop.Shared.ModelView;
using System.IO;
using AspNetShop.Client.Pages;
using AspNetShop.Server.Domain;

namespace AspNetShop.Server.Controllers
{
    [ApiController]
    [Route("{controller}/{action=Get}")]
    public class CatalogController : ControllerBase
    {
        const int CountOnPage = 5;
        private readonly DataManager dataManager;

        public CatalogController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return dataManager.Categories.GetCategories();
        }

        [HttpGet]
        public ProductList LoadProducts(int cat, int page)
        {
            page--;
            var list = dataManager
                .Products.GetProducts()
                .Where(p => p.CategoryId == cat);

            ProductList pl = new ProductList();
            pl.CountOfPages = (int)Math.Ceiling((double)list.Count() / CountOnPage);
            list = list.Skip(page*CountOnPage);
            if (list.Count() > CountOnPage)
                list = list.Take(CountOnPage);
            pl.Products = list;

            return pl;
        }

        [HttpGet]
        public string GetName(int cat)
        {
            return this.Get()
                .FirstOrDefault(category => category.Id == cat)
                ?.Name;
        }

        [HttpGet]
        public Product GetProduct(int id)
        {
            return dataManager.Products.GetProduct(id);
        }

        [HttpGet]
        public string GetProductDescription(int id)
        {
            return dataManager.Products.GetProduct(id)?.Description;
        }

        [HttpGet]
        public IEnumerable<Product> ShortFindProducts(string pattern)
        {
            var resultList = new List<Product>();
            foreach (var product in dataManager.Products.GetProducts())
            {
                if (product.Name.Contains(pattern))
                {
                    resultList.Add(product);
                }
            }

            return resultList.Take(4).ToArray();
        }

        [HttpGet]
        public string[] GetImagesProduct(int id)
        {
            return new string[4] { "images/1.jpg", "images/2.jpg", "images/3.jpg", "images/4.jpg" };
        }

        [HttpGet]
        public ProductList FindProducts(string pattern, int page)
        {
            page--;
            var resultList = new List<Product>();
            foreach (var product in dataManager.Products.GetProducts())
            {
                if (product.Name.Contains(pattern))
                {
                    resultList.Add(product);
                }
            }

            var list = resultList.AsEnumerable();

            ProductList pl = new ProductList();
            pl.CountOfPages = (int) Math.Ceiling((double)list.Count() / CountOnPage);
            list = list.Skip(page * CountOnPage);

            if (list.Count() > CountOnPage)
                list = list.Take(CountOnPage);

            pl.Products = list;

            return pl;
        }

        [HttpGet]
        public IEnumerable<Product> ShortNewProducts()
        {
            var list = dataManager
                .Products.GetProducts()
                .OrderBy(x => x.TimeAdded).Take(6);

            return list.ToArray();
        }

        [HttpGet]
        public IEnumerable<Product> ShortTopProducts()
        {
            var list = dataManager
                .Products.GetProducts()
                .OrderBy(x => x.Rating)
                .Take(6);

            return list.ToArray();
        }
    }
}
