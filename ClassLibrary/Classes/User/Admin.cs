using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.User
{
    public class Admin : User
    {
        public string UserName { get; set; }

        public Admin() { }

        public Admin(int id,string username, string email, string password, UserType userType)
        {
            Id = id;
            UserName = username;
            Email = email;
            Password = password;
            UserType = userType;
        }
    }
}
