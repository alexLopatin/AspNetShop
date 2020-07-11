using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.Server.Data
{
    public class AspNetShopServerContext : DbContext
    {
        public AspNetShopServerContext (DbContextOptions<AspNetShopServerContext> options)
            : base(options)
        {
        }

        public DbSet<AspNetShop.Shared.ModelView.Product> Product { get; set; }

        public DbSet<AspNetShop.Shared.ModelView.Category> Categories { get; set; }
    }
}
