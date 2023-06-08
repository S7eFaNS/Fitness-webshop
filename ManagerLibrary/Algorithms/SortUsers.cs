using ClassLibrary.Classes.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.Algorithm
{
    public class SortUsers
    {
        public SortUsers() { }

        public List<User> SortByUserTypeAdmin(List<User> admins)
        {
            return admins = admins.Where(admin => admin.UserType == UserType.Admin).ToList();
        }

        public List<User> SortByUserTypeCustomer(List<User> customers)
        {
            return customers = customers.Where(customer => customer.UserType == UserType.Customer).ToList();
        }
    }
}
