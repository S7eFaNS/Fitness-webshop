using ClassLibrary.Classes.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.IRepositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> GetUsers();
        User GetUserByEmail(string email);
        bool CreateUser(User user);
        bool DeleteUser(User user);
        bool UpdateUser(User user);
        List<User> SearchUsers(string searchQuery);
        string GetSalt(string email);
        User? CheckLogin(string email, string password);

    }
}
