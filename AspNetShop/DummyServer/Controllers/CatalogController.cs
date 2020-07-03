using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetShop.Shared.ModelView;
using System.IO;

namespace AspNetShop.DummyServer.Controllers
{
    
    [ApiController]
    [Route("{controller}/{action=Get}")]
    public class CatalogController : ControllerBase
    {
        const int CountOnPage = 5;
        private readonly DataLoader _loader;
        public CatalogController(DataLoader loader)
        {
            _loader = loader;
        }
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var list = _loader.Get<Category>();
            return list.ToArray();
        }
        [HttpGet]
        public ProductList LoadProducts(int cat, int page)
        {
            page--;
            var list = _loader.Get<Product>().Where(p => p.CategoryId == cat);
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
            var list = _loader.Get<Category>();
            return list.Find(c => c.Id == cat).Name;
        }

        [HttpGet]
        public Product GetProduct(int id)
        {
            var list = _loader.Get<Product>();
            return list.Find(c => c.Id == id);
        }
        [HttpGet]
        public string GetProductDescription(int id)
        {
            if (System.IO.File.Exists(String.Format("ProductDescriptions/{0}.html", id)))
                return System.IO.File.ReadAllText(String.Format("ProductDescriptions/{0}.html", id));
            else
                return "";
        }
        [HttpGet]
        public IEnumerable<Product> ShortFindProducts(string pattern)
        {
            Random rnd = new Random();
            var list = _loader.Get<Product>().OrderBy(x => rnd.Next()).Take(4);
            return list.ToArray();
        }
        [HttpGet]
        public ProductList FindProducts(string pattern, int page)
        {
            page--;
            var list = _loader.Get<Product>().AsEnumerable();
            ProductList pl = new ProductList();
            pl.CountOfPages = (int)Math.Ceiling((double)list.Count() / CountOnPage);
            //if (page < 0 || page * CountOnPage >= list.Count())
            //    list.
            list = list.Skip(page * CountOnPage);
            if (list.Count() > CountOnPage)
                list = list.Take(CountOnPage);
           
            pl.Products = list;
            
            return pl;
        }
    }
}
