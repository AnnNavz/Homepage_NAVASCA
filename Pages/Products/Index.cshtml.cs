using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Homepage_NAVASCA.Data;
using Homepage_NAVASCA.Models;

namespace Homepage_NAVASCA.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Homepage_NAVASCA.Data.Homepage_NAVASCAContext _context;

        public IndexModel(Homepage_NAVASCA.Data.Homepage_NAVASCAContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
