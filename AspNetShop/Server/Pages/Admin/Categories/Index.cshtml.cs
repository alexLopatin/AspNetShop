using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetShop.Server.Data;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.Server.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AspNetShop.Server.Data.AspNetShopServerContext _context;

        public IndexModel(AspNetShop.Server.Data.AspNetShopServerContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
