using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymProject.Pages
{
    public class ProfileModel : PageModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                FirstName = User.FindFirstValue(ClaimTypes.GivenName);
                LastName = User.FindFirstValue(ClaimTypes.Surname);
                Email = User.FindFirstValue(ClaimTypes.Email);
            }
        }
    }
}

