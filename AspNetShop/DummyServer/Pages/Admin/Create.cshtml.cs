using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetShop.DummyServer.Data;
using AspNetShop.Shared.ModelView;

namespace AspNetShop.DummyServer.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly AspNetShop.DummyServer.Data.AppContext _context;

        public CreateModel(AspNetShop.DummyServer.Data.AppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product prodModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(prodModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
