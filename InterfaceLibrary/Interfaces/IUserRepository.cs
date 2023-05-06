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
        //User
        bool CreateUser(User user);
        bool DeleteUser(User user);
        bool UpdateUser(User user);
        User GetUserById(int id);
        List<User> GetUsers();
        //Admin
        bool CreateAdmin(Admin admin);
        bool DeleteAdmin(Admin admin);
        Admin GetAdminById(int adminId);
        List<Admin> GetAdmins();
        //Customer
        bool CreateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        Customer GetCustomerById(int customerId);
        List<Customer> GetCustomers();
        //Login
        User? CheckLogin(string email, string password);

    }
}
