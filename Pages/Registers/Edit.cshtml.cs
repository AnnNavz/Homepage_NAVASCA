using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Homepage_NAVASCA.Data;
using Homepage_NAVASCA.Models;

namespace Homepage_NAVASCA.Pages.Registers
{
    public class EditModel : PageModel
    {
        private readonly Homepage_NAVASCA.Data.Homepage_NAVASCAContext _context;

        public EditModel(Homepage_NAVASCA.Data.Homepage_NAVASCAContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Register Register { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register =  await _context.Register.FirstOrDefaultAsync(m => m.ProfileId == id);
            if (register == null)
            {
                return NotFound();
            }
            Register = register;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Register).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(Register.ProfileId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RegisterExists(string id)
        {
            return _context.Register.Any(e => e.ProfileId == id);
        }
    }
}
