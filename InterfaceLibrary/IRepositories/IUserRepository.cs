using ClassLibrary.Classes.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.IRepositories
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
        Admin GetAdminById(int adminId);
        List<Admin> GetAdmins();

        //Customer
        Customer GetCustomerById(int customerId);
        List<Customer> GetCustomers();

        //Login
        User? CheckLogin(string email, string password);

    }
}
