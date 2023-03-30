using Database.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.User
{
    public class User : Entity
    {
        [ColumnName("first_name")]
        private string FirstName { get; set; }

        [ColumnName("last_name")]
        private string LastName { get; set; }

        [ColumnName("password")]
        private string Password { get; set; }

        [ColumnName("email")]
        private string Email { get; set; }

        public User(int id, string firstName, string lastName, string password, string email)
        {
            this.SetId(id);
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
        }
        public User() { }
    }
}
