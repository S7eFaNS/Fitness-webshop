using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.User
{
    public class Admin : User
    {

        public Admin() 
        {
            UserType = UserType.Admin;
        }

        public Admin(int id, string firstName, string lastName, string email, string password)
        : base(id, firstName, lastName, email, password, UserType.Admin)
        {
        }
    }
}
