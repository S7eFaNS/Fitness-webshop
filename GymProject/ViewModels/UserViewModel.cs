using ClassLibrary.Classes.User;
using System.ComponentModel.DataAnnotations;

namespace GymProject.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        public string Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public UserType UserType { get; set; }
    }
}
