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
    public class CartController : Controller
    {
        private readonly DataLoader _loader;
        public CartController(DataLoader loader)
        {
            _loader = loader;
        }
        [HttpPost]
        public IEnumerable<Product> Get(Dictionary<string,int> products)
        {
            var list = _loader.Get<Product>().Where(x => products.ContainsKey(x.Id.ToString()));
            return list.ToArray();
        }
    }
}
