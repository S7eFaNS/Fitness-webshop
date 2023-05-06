using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace GymProject.Pages
{
    [Authorize(Roles = "Admin, Customer")]
    public class ShoppingCart : PageModel
    {
        public void OnGet()
        {
        }
    }
}