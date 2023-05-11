using ClassLibrary.Classes.User;
using Database.DataBase;
using InterfaceLibrary.IManagers;
using InterfaceLibrary.IRepositories;
using ManagerLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.ManagerClasses
{
    public class UserManager /*: IUserManager*/
    {
        private readonly IUserRepository repository;

        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        public List<User> GetUsers()
        {
            return repository.GetUsers();
        }

        public User GetUserById(int id)
        {
            return repository.GetUserById(id);
        }

        public User GetUserByEmail(string email)
        {
            return repository.GetUserByEmail(email);
        }

        public List<User> SearchUsers(string searchQuery)
        {
            return repository.SearchUsers(searchQuery);
        }

        //public User GiveUserRole(User user)
        //{
        //    switch (user.UserType.ToString())
        //    {
        //        case "Admin":
        //            return repository.GetAdminById(user.Id);
        //        case "Customer":
        //            return repository.GetCustomerById(user.Id);
        //        default:
        //            throw new ArgumentException("Invalid input type");
        //    }
        //}

        public bool CreateUser(User user)
        {
            if (user is Admin)
            {
                var admin = user as Admin;
                return repository.CreateUser(admin);
            }
            else if (user is Customer)
            {
                var customer = user as Customer;
                return repository.CreateUser(customer);
            }
            else
            {
                throw new ArgumentException("Invalid user type");
            }
        }

        public bool UpdateUser(User user)
        {
            if (user is Admin)
            {
                var admin = user as Admin;
                return repository.UpdateUser(admin);
            }
            else if (user is Customer)
            {
                var customer = user as Customer;
                return repository.UpdateUser(customer);
            }
            else
            {
                throw new ArgumentException("Invalid user type");
            }
        }

        public bool DeleteUser(int id)
        {
            User user = repository.GetUserById(id);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            else if (user.UserType == UserType.Admin)
            {
                return repository.DeleteUser(user);
            }
            else if (user.UserType == UserType.Customer)
            {
                return repository.DeleteUser(user);
            }
            else
            {
                throw new ArgumentException("Invalid user type");
            }
        }
    }
}
