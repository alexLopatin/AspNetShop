using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Server.Data;
using AspNetShop.Server.Domain.Repositories.Abstract;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.Server.Domain.Repositories.EntityFramework
{
    public class EFStockRepository : IStockRepository
    {
        private AppDbContext context;

        public EFStockRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Stock> GetStocks()
        {
            return context.Stock;
        }
    }
}
