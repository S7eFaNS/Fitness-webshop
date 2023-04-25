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

        //User
        //public bool CreateUser(User user);

        //public bool UpdateUser(User user);

        public bool DeleteUser(int id);
        public User GetUserById(int id);
        public bool UpdateUser(List<object> eventElements);

        ////Admin
        //public bool CreateAdmin(Admin admin);

        //public bool UpdateAdmin(Admin admin);

        //public bool DeleteAdmin(Admin admin);

        ////Customer
        //public bool CreateCustomer(Customer customer);

        //public bool UpdateCustomer(Customer customer);

        //public bool DeleteCustomer(Customer customer);
    }
}
