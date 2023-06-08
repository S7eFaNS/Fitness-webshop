using ClassLibrary.Classes.User;
using System.ComponentModel.DataAnnotations;

namespace GymProject.ViewModels
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 99, ErrorMessage = "Age must be between 18 and 99.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }
        public UserType UserType { get; set; } = UserType.Customer;

        public Customer ToCustomer()
        {
            return new Customer
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                Email = Email,
                Password = Password,
                UserType = UserType.Customer
            };
        }
    }
}
