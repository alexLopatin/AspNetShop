using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetShop.Shared.ModelView;

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
        public IEnumerable<Product> LoadProducts(int cat, int page)
        {
            page--;
            var list = _loader.Get<Product>().Where(p => p.CategoryId == cat);
            if (page < 0 || page * CountOnPage >= list.Count())
                return null;
            list = list.Skip(page*CountOnPage);
            if (list.Count() > CountOnPage)
                list = list.Take(CountOnPage);
            return list;
        }
    }
}
