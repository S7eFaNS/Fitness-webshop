using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymProject.Pages
{
    public class LogOutModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            await HttpContext.SignOutAsync();
            Response.Cookies.Delete("UserEmail");
            Response.Cookies.Delete("UserID");
            return RedirectToPage("/SignIn");
        }
    }
}
