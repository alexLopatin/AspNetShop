using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetShop.Server.Domain.Repositories.Abstract;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.Server.Domain.Repositories.EntityFramework
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private AppDbContext context;

        public EFCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Category> GetCategories()
        {
            return context.Categories;
        }
    }
}