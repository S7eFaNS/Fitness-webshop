using ClassLibrary.Classes.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.Interfaces
{
    public interface IUserManager
    {
        public List<User> GetUsers();
        public User GetUserById(int id);
        public User GetUserByEmail(string email);

        //int GetNextUserId();
        //User
        public bool CreateUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(int id);

        ////Admin
        //public bool CreateAdmin(Admin admin);
        //public bool UpdateAdmin(Admin admin);
        //public bool DeleteAdmin(Admin admin);
        //Admin GetAdminById(int adminId);
        //List<Admin> GetAdmins();

        ////Customer
        //public bool CreateCustomer(Customer admin);
        //public bool UpdateCustomer(Customer admin);
        //public bool DeleteCustomer(Customer admin);
        //Customer GetCustomerById(int customerId);
        //List<Customer> GetCustomers();
    }
}
