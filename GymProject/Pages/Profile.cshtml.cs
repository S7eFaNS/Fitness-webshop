using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymProject.Pages
{
    [Authorize(Roles = "Admin, Customer")]
    public class ProfileModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
