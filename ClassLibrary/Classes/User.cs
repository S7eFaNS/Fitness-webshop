using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes
{
    public class User
    {
        private string name;
        private string password;
        private string email;

        public User(string name, string password, string email)
        {
            GetName = name;
            GetPassword = password;
            GetEmail = email;
        }

        public string GetName 
        {
            get { return name; }
            set { name = value; }
        }
        public string GetPassword
        {
            get { return password; }
            set { password = value; }
        }
        public string GetEmail
        {
            get { return email; }
            set { email = value; }
        }
    }
}
