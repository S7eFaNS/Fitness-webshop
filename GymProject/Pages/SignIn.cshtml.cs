using ClassLibrary.Classes.User;
using ManagerLibrary.ManagerClasses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Security.Claims;

namespace GymProject.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    public class SignInModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        public string? ErrorMessage { get; set; }

        private readonly ILogger<SignInModel> _logger;

        public SignInModel(ILogger<SignInModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Please fill in all of the boxes above";
                return Page();
            }

            if (user.Email == "admin@gmail.com" && user.Password == "password")
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
        };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }

            ModelState.AddModelError("", "Invalid login attempt");
            return Page();
        }

    }
}