using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Server.Domain;
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
        private readonly DataManager dataManager;
        public StockController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        [HttpGet]
        public IEnumerable<Stock> Get()
        {
            return dataManager.Stocks.GetStocks();
        }
    }
}
