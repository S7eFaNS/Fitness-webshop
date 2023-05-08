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

        public User GiveUserRole(User user)
        {
            switch (user.UserType.ToString())
            {
                case "Admin":
                    return repository.GetAdminById(user.Id);
                case "Customer":
                    return repository.GetCustomerById(user.Id);
                default:
                    throw new ArgumentException("Invalid input type");
            }
        }

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
            var user = repository.GetUserById(id);
            if (user is Admin)
            {
                var admin = user as Admin;
                return repository.DeleteUser(admin) && repository.DeleteAdmin(admin);
            }
            else if (user is Customer)
            {
                var customer = user as Customer;
                return repository.DeleteUser(customer) && repository.DeleteCustomer(customer);
            }
            else
            {
                throw new ArgumentException("Invalid user type");
            }
        }


        //public bool CreateAdmin(Admin admin)
        //{
        //    if (repository.CreateUser(admin) && repository.CreateAdmin(admin)) 
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public bool UpdateAdmin(Admin admin)
        //{
        //    if (repository.UpdateUser(admin) && repository.UpdateAdmin(admin))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public bool DeleteAdmin(Admin admin)
        //{
        //    if(repository.DeleteUser(admin) && repository.DeleteAdmin(admin))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public Admin GetAdminById(int adminId)
        //{
        //    return repository.GetAdminById(adminId);
        //}

        //public List<Admin> GetAdmins()
        //{
        //    return repository.GetAdmins();
        //}

        //public bool CreateCustomer(Customer customer)
        //{
        //    if (repository.CreateUser(customer) && repository.CreateCustomer(customer))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public bool UpdateCustomer(Customer customer)
        //{
        //    if (repository.UpdateUser(customer) && repository.UpdateCustomer(customer))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public bool DeleteCustomer(Customer customer)
        //{
        //    if (repository.DeleteUser(customer) && repository.DeleteCustomer(customer))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public Customer GetCustomerById(int customerId)
        //{
        //    return repository.GetCustomerById(customerId);
        //}

        //public List<Customer> GetCustomers()
        //{
        //    return repository.GetCustomers();
        //}

        //public bool DeleteUser(int id)
        //{
        //    User user = repository.GetUserById(id);
        //    return repository.DeleteUser(user);
        //}
    }
}
