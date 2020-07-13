using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Server.Data;
using AspNetShop.Server.Domain.Repositories.Abstract;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.Server.Domain.Repositories.EntityFramework
{
    public class EFUserOrderRepository : IUserOrderRepository
    {
        private AppDbContext context;

        public EFUserOrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProductsFromUser(int userId)
        {
            

            throw new NotImplementedException();
        }
    }
}
