using ClassLibrary.Classes.User;
using GymProject.ViewModels;
using ManagerLibrary.ManagerClasses;
using ManagerLibrary.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Security.Claims;

namespace GymProject.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public UserLoginModel LoggingUser { get; set; }

        public readonly ManagerLibrary.ManagerClasses.AuthenticationService authenticationService = new ManagerLibrary.ManagerClasses.AuthenticationService(new UserRepository());
        public string? ErrorMessage { get; set; }

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
                if (string.IsNullOrEmpty(LoggingUser.Email) || string.IsNullOrEmpty(LoggingUser.Password))
                {
                    ErrorMessage = "Please enter your credentials";
                    return Page();
                }

                User? loggedUser = authenticationService.CheckLogin(LoggingUser.Email, LoggingUser.Password);

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Email, loggedUser.Email));
                claims.Add(new Claim(ClaimTypes.Role, loggedUser.UserType.ToString()));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties();

                if (!Request.Form.ContainsKey("RememberMe"))
                {
                    authProperties.ExpiresUtc = DateTime.UtcNow.AddMinutes(10);
                    authProperties.IsPersistent = false;
                }
                else
                {
                    authProperties.ExpiresUtc = DateTime.UtcNow.AddDays(5);
                    authProperties.IsPersistent = true;
                }

                HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                string? returnUrl = Request.Query["ReturnUrl"];
                if (string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToPage("/Profile");
                }
                return RedirectToPage(returnUrl);   
            }
            catch (Exception ex)
            {
                ErrorMessage = "Incorrect email or password";
                return Page();
            }

        }


    }
}
