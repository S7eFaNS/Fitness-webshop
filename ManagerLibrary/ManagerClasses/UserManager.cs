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

        public User CreateUserInstance(List<object> eventElements)
        {
            //ToDoNext
            UserType userType = (UserType)Enum.Parse(typeof(UserType), eventElements[6].ToString());

            User user = new User();
            user.Id = (int)eventElements[0];
            user.GetFirstName = (string)eventElements[1];
            user.GetLastName = (string)eventElements[2];
            user.GetEmail = (string)(eventElements[4]);
            user.GetPassword = (string)eventElements[5];
            user.GetUserType = userType;

            return user;
        }

        public List<User> GetUsers()
        {
            return repository.GetUsers();
        }

        //public User GiveUserRole(User user)
        //{
        //    switch (user.GetUserType.ToString())
        //    {
        //        case "Admin":
        //            return repository.GetAdminById(user.Id);
        //        case "Customer":
        //            return repository.GetCustomerById(user.Id);
        //        default:
        //            throw new ArgumentException("Invalid input type");
        //    }
        //}

        public User GetUserById(int id)
        {
            return repository.GetUserById(id);
        }

        public bool CreateUser(List<object> eventElements)
        {
            User user = CreateUserInstance(eventElements);
            return repository.CreateUser(user);
        }

        public bool UpdateEvent(List<object> eventElements)
        {
            User user = CreateUserInstance(eventElements);
            return repository.UpdateUser(user);
        }

        public bool DeleteUser(int id)
        {
            User user = repository.GetUserById(id);
            return repository.DeleteUser(user);
        }
    }
}
