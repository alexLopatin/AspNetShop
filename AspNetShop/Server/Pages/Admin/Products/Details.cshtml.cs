using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetShop.Server.Data;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.Server.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly AspNetShop.Server.Data.AspNetShopServerContext _context;

        public DetailsModel(AspNetShop.Server.Data.AspNetShopServerContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
