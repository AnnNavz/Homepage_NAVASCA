using Homepage_NAVASCA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Homepage_NAVASCA.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]

        public Users users { get; set; } = new Users();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (users.Username == "Admin" && users.Password == "Admin123!")
            {
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");

                return Page();
            }
        }
    }
}
