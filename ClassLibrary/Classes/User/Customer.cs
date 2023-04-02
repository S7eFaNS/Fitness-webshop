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
            this.SetId(id);
            GetFirstName = firstName;
            GetLastName = lastName;
            GetEmail = email;
            GetPassword = password;
            GetUserType = userType;
        }
    }
}
