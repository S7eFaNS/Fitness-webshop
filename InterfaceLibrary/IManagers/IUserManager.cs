using ClassLibrary.Classes.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.IManagers
{
    public interface IUserManager
    {
        public List<User> GetUsers();
        public User GetUserById(int id);
        public User GetUserByEmail(string email);
        List<User> SearchUsers(string searchQuery);
        public bool CreateUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(int id);
    }
}
