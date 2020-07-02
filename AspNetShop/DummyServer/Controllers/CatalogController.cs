using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.DummyServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
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
    }
}
