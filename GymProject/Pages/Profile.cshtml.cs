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
                Email = User.FindFirstValue(ClaimTypes.Email);
            }
            else
            {
                if (Request.Cookies.TryGetValue("UserEmail", out string userEmail) &&
                    Request.Cookies.TryGetValue("UserID", out string userId))
                {
                    Email = userEmail;
                }
            }
        }
    }
}

