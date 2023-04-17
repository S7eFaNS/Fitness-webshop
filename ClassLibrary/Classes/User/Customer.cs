using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.User
{
    public class Customer : User
    {
        public Customer() { }

        public Customer(int id, string firstName, string lastName, string email, string password, UserType userType)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserType = userType;
        }
    }
}
