using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.User
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Id field is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName field is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email field is required")]
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
