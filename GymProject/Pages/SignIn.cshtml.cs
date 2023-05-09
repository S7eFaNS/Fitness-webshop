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
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    public class SignInModel : PageModel
    {
        [BindProperty]
        public UserViewModel LoggingUser { get; set; }
        [BindProperty]
        public bool KeepMeLoggedIn { get; set; }

        public readonly InterfaceLibrary.IManagers.IAuthenticationService authenticationService = new ManagerLibrary.ManagerClasses.AuthenticationService(new UserRepository());
        public string? ErrorMessage { get; set; }
        public string? RequestId { get; private set; }


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
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync();

            if (IsUserLoggedIn())
            {
                return RedirectToPage("/Profile");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            bool keepMeLoggedIn = false;

            User? LoggedUser = authenticationService.CheckLogin(LoggingUser.Email, LoggingUser.Password);
            
            if (LoggedUser == null)
            {
                ErrorMessage = "Incorrect email or password";
                return Page();
            }

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, LoggedUser.Email));
            claims.Add(new Claim(ClaimTypes.Role, LoggedUser.UserType.ToString()));

            HttpContext.Session.SetString("UserEmail", LoggedUser.Email);
            HttpContext.Session.SetString("UserID", LoggedUser.Id.ToString());

            if (keepMeLoggedIn)
            {
                CookieOptions cOptions = new CookieOptions();
                cOptions.Expires = DateTime.Now.AddDays(5);
                Response.Cookies.Append("UserEmail", LoggedUser.Email, cOptions);
                Response.Cookies.Append("UserID", LoggedUser.Id.ToString(), cOptions);
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

            string? returnUrl = Request.Query["ReturnUrl"];
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToPage("/Profile");
            }

            return RedirectToPage(returnUrl);
        }

    }
}