using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Server.Domain;
using AspNetShop.Server.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.Server.Controllers
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
            var list = new List<Product>();
            foreach (var product in products) {
                foreach (var prod in dataManager.Products.GetProducts())
                {
                    if (prod.Id == int.Parse(product.Key)) {
                        list.Add(prod.ToProduct());
                    }
                }
            }
            
            return list;
        }
    }
}
