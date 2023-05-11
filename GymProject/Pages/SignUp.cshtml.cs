using ClassLibrary.Classes.User;
using ManagerLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace GymProject.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public Customer customer { get; set; }
        public string PagerTitle { get; private set; }

        public readonly ManagerLibrary.ManagerClasses.AuthenticationService authenticationService;

        public SignUpModel()
        {
            PagerTitle = "Please sign up";
            authenticationService = new ManagerLibrary.ManagerClasses.AuthenticationService(new UserRepository());
            customer = new Customer();
            //customer.UserType = UserType.Customer;
        }

        public bool IsUserLoggedIn()
        {
            string? userEmail = HttpContext.Session.GetString("UserEmail");
            if (userEmail != null)
            {
                return true;
            }

            userEmail = Request.Cookies["UserEmail"];
            string userId = Request.Cookies["UserID"];

            if (userEmail != null && userId != null)
            {
                HttpContext.Session.SetString("UserEmail", userEmail);
                HttpContext.Session.SetString("UserID", userId);
                return true;
            }
            return false;
        }

        public IActionResult OnGet()
        {
            //HttpContext.Session.Clear();
            //HttpContext.SignOutAsync();

            if (IsUserLoggedIn())
            {
                return RedirectToPage("/Profile");
            }
            return Page();
        }

        public IActionResult OnPost() 
        {

            bool result = authenticationService.Register(customer);
            
            if (!result)
            {
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, customer.FirstName),
                new Claim(ClaimTypes.Email, customer.Email),
                new Claim(ClaimTypes.Role, UserType.Customer.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(5)
            };

            HttpContext.SignInAsync(
                 CookieAuthenticationDefaults.AuthenticationScheme,
                 new ClaimsPrincipal(claimsIdentity),
                 authProperties
             );

            return RedirectToPage("/Profile");
        }
    }
}
