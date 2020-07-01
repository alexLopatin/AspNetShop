using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Shared;
using AspNetShop.Shared.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace AspNetShop.DummyServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly DataLoader _loader;
        public StockController(DataLoader loader)
        {
            _loader = loader;
        }
        [HttpGet]
        public IEnumerable<Stock> Get()
        {
            var list = _loader.Get<Stock>();
            return list.ToArray();
        }
    }
}
