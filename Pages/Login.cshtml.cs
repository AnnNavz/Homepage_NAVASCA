using Homepage_NAVASCA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Homepage_NAVASCA.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // The constructor "injects" the database connection here
        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Users users { get; set; } = new Users();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // 1. Search the 'Registers' table for a matching username
            // We use FirstOrDefault so it returns null if no user is found
            var dbUser = _context.Register
                .FirstOrDefault(u => u.Username == users.Username);

            // 2. Validate the user exists and the password matches
            if (dbUser != null && dbUser.Password == users.Password)
            {
                // Success! 
                // In a real app, you would set a Session or Cookie here
                return RedirectToPage("/Index");
            }

            // 3. If login fails, add an error and stay on the page
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return Page();
        }
    }
}
