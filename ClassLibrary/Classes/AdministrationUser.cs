using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes
{
    public class AdministrationUser
    {
        private List<User> users;
        
        public AdministrationUser() { }

        public List<User> AllUsers { get { return users;} }

        public void AddUser(User user) 
        { 
            users.Add(user);
        }

        public void RemoveUser(User user)
        {
            users.Remove(user);
        }
    }
}
