using ClassLibrary.Classes.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.Interfaces
{
    public interface IUserRepository
    {
        bool CreateUser(User user);
        bool DeleteUser(User user);
        User GetUserById(int id);
        List<User> GetUsers();
        bool UpdateUser(User user);
        User? CheckLogin(string email, string password);

    }
}
