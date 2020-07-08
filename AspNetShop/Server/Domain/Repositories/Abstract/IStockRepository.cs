using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.Server.Domain.Repositories.Abstract
{
    public interface IStockRepository
    {
        public IQueryable<Stock> GetStocks();
    }
}
