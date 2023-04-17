using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.User
{
    public class Admin : User
    {
        public Admin() { }

        public Admin(/*int id, */string firstName, string lastName, string email, string password, UserType userType)
        {
            /*this.SetId(id)*/;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserType = userType;
        }
    }
}
