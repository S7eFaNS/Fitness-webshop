using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes
{
    public class AdministrationUser
    {
        private List<User> users { get; set; }
        
        public AdministrationUser() { }

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
