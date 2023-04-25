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
        private readonly IUserRepository repository;

        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        public User CreateUserInstance(List<object> userElements)
        {
            //ToDoNext
            UserType userType = (UserType)Enum.Parse(typeof(UserType), userElements[6].ToString());

            User user = new User();
            user.Id = (int)userElements[0];
            user.FirstName = (string)userElements[1];
            user.LastName = (string)userElements[2];
            user.Email = (string)(userElements[4]);
            user.Password = (string)userElements[5];
            user.UserType = userType;

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

        public bool UpdateUser(List<object> eventElements)
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
