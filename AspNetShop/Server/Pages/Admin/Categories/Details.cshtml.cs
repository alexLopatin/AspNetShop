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
    public class DetailsModel : PageModel
    {
        private readonly AspNetShop.Server.Data.AspNetShopServerContext _context;

        public DetailsModel(AspNetShop.Server.Data.AspNetShopServerContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
