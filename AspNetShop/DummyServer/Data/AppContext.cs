using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.DummyServer.Data
{
    public class AppContext : DbContext
    {
        public AppContext (DbContextOptions<AppContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<AspNetShop.Shared.ModelView.Product> Product { get; set; }
    }
}
