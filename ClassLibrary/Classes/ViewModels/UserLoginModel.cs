using ClassLibrary.Classes.User;
using System.ComponentModel.DataAnnotations;

namespace GymProject.ViewModels
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Email field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        public string Password { get; set; }
    }
}
