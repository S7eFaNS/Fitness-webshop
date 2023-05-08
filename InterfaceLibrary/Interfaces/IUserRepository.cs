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
        User GetUserById(int id);
        List<User> GetUsers();
        User GetUserByEmail(string email);
        
        //User
        bool CreateUser(User user);
        bool DeleteUser(User user);
        bool UpdateUser(User user);
        
        //Admin
        bool DeleteAdmin(Admin admin);
        //bool UpdateAdmin(Admin admin);
        Admin GetAdminById(int adminId);
        List<Admin> GetAdmins();
        
        //Customer
        bool DeleteCustomer(Customer customer);
        //bool UpdateCustomer(Customer customer);
        Customer GetCustomerById(int customerId);
        List<Customer> GetCustomers();
        
        //Login
        User? CheckLogin(string email, string password);

    }
}
