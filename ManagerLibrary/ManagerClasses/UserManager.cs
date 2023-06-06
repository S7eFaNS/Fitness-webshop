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
using static ClassLibrary.Classes.Delegates.Delegate;

namespace ManagerLibrary.ManagerClasses
{
    public class UserManager
    {
        private readonly IUserRepository repository;
        
        public event AdminCreatedEventHandler AdminCreated;
        public event UserEditedEventHandler UserEdited;
        public event UserDeletedEventHandler UserDeleted;

        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        public List<User> GetUsers()
        {
            List<User> users = repository.GetUsers();
            return users;
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

        public bool CreateUser(User user)
        {

            if (user is Admin)
            {
                var admin = user as Admin;
                bool created = repository.CreateUser(admin);

                if (created)
                {
                    OnAdminCreated(EventArgs.Empty);
                }

                return created;
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
                bool edited = repository.UpdateUser(admin);

                if(edited)
                {
                    OnUserEdited(EventArgs.Empty);
                }
                return edited;
            }
            else if (user is Customer)
            {
                var customer = user as Customer;
                bool edited = repository.UpdateUser(customer);

                if (edited)
                {
                    OnUserEdited(EventArgs.Empty);
                }
                return edited;
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
                bool deleted = repository.DeleteUser(user);

                if (deleted)
                {
                    OnUserDeleted(EventArgs.Empty);
                }
                return deleted;
            }
            else if (user.UserType == UserType.Customer)
            {
                bool deleted = repository.DeleteUser(user);

                if (deleted)
                {
                    OnUserDeleted(EventArgs.Empty);
                }
                return deleted;
            }
            else
            {
                throw new ArgumentException("Invalid user type");
            }
        }

        protected virtual void OnAdminCreated(EventArgs e)
        {
            AdminCreated?.Invoke(this, e);
        }
        protected virtual void OnUserDeleted(EventArgs e)
        {
            UserDeleted?.Invoke(this, e);
        }
        protected virtual void OnUserEdited(EventArgs e)
        {
            UserEdited?.Invoke(this, e);
        }
    }
}
