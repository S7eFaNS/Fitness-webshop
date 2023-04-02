using ClassLibrary.Classes.User;
using Database.DataBase;
using InterfaceLibrary.Interfaces;
using ManagerLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.ManagerClasses
{
    public class UserManager : IUserManager
    {
        private UserRepository repository = new UserRepository();

        public UserManager() { }

        public List<User> GetAllUsers()
        {
            List<User> users = repository.GetUsers();
            return users;
        }

        public bool DeleteUser(User user)
        {
            if (repository.DeleteUser(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
