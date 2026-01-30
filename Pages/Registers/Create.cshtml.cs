using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Homepage_NAVASCA.Data;
using Homepage_NAVASCA.Models;

namespace Homepage_NAVASCA.Pages.Registers
{
    public class CreateModel : PageModel
    {
        private readonly Homepage_NAVASCA.Data.Homepage_NAVASCAContext _context;

        public CreateModel(Homepage_NAVASCA.Data.Homepage_NAVASCAContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Register Register { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Register.Add(Register);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
