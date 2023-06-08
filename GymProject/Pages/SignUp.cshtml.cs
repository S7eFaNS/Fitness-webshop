using ClassLibrary.Classes.User;
using ManagerLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using GymProject.ViewModels;
using ManagerLibrary.ManagerClasses;

namespace GymProject.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public UserRegistrationModel customer { get; set; }
        public string PagerTitle { get; private set; }

        public readonly ManagerLibrary.ManagerClasses.AuthenticationService authenticationService;

        public SignUpModel()
        {
            PagerTitle = "Please sign up";
            authenticationService = new ManagerLibrary.ManagerClasses.AuthenticationService(new UserRepository());
            customer = new UserRegistrationModel();
        }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Profile");
            }

            return Page();
        }

        public IActionResult OnPost() 
        {
            try
            {
                if (string.IsNullOrEmpty(customer.FirstName) ||
                string.IsNullOrEmpty(customer.LastName) ||
                customer.Age <= 0 ||
                string.IsNullOrEmpty(customer.Email) ||
                string.IsNullOrEmpty(customer.Password))
                {
                    ModelState.AddModelError("", "Please fill in all the required fields.");
                    return Page();
                }

                UserValidationService userValidation = new UserValidationService();

                if (! userValidation.IsFirstNameValid(customer.FirstName))
                {
                    ModelState.AddModelError("customer.FirstName", "First name should start with an uppercase letter and contain only lowercase letters afterwards.");
                }

                if (!userValidation.IsLastNameValid(customer.LastName))
                {
                    ModelState.AddModelError("customer.LastName", "Last name should start with an uppercase letter and contain only lowercase letters afterwards.");
                }

                if (!userValidation.IsEmailValid(customer.Email))
                {
                    ModelState.AddModelError("customer.Email", "Please enter a valid email address.");
                }

                if (!userValidation.IsPasswordValid(customer.Password))
                {
                    ModelState.AddModelError("customer.Password", "Password should be at least 8 characters long and contain at least one uppercase letter and one number.");
                }

                if (customer.Age > 100)
                {
                    ModelState.AddModelError("customer.Age", "Age should be less than or equal to 100.");
                }

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                bool result = authenticationService.Register(customer);
            
                if (!result)
                {
                    ModelState.AddModelError("customer.Email", "Email is already registered");
                    return Page();
                }

                var claims = new List<Claim>
                {
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
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred during the sign-up process.");
                return Page();
            }
        }
    }
}
