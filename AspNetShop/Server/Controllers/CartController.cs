using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Server.Domain;
using Microsoft.AspNetCore.Mvc;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.DummyServer.Controllers
{
    [ApiController]
    [Route("{controller}/{action=Get}")]
    public class CartController : Controller
    {
        private readonly DataManager dataManager;
        public CartController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        [HttpPost]
        public IEnumerable<Product> Get(Dictionary<string,int> products)
        {
            return dataManager.Products.GetProducts();
        }
    }
}
