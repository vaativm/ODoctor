using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ODoctor.Infrastructure.Identity;

namespace ODoctor.UI.Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<ODoctorUser> _signInManager;

        public IndexModel(SignInManager<ODoctorUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToPage("/Dashboard/Index");
            return Page();
        }
    }
}
