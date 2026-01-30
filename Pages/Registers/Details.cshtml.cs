using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Homepage_NAVASCA.Data;
using Homepage_NAVASCA.Models;

namespace Homepage_NAVASCA.Pages.Registers
{
    public class DetailsModel : PageModel
    {
        private readonly Homepage_NAVASCA.Data.Homepage_NAVASCAContext _context;

        public DetailsModel(Homepage_NAVASCA.Data.Homepage_NAVASCAContext context)
        {
            _context = context;
        }

        public Register Register { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Register.FirstOrDefaultAsync(m => m.ProfileId == id);
            if (register == null)
            {
                return NotFound();
            }
            else
            {
                Register = register;
            }
            return Page();
        }
    }
}
