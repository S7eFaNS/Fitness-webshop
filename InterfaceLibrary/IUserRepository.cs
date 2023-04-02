using ClassLibrary.Classes.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public interface IUserRepository
    {
        List<User> ReadAll(string name);
        List<User> GetUsers();
        bool DeleteUser(User user);
    }
}
