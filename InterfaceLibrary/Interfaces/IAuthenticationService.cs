using ClassLibrary.Classes.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.Interfaces
{
    public interface IAuthenticationService
    {
        public User? CheckLogin(string email, string password);
    }
}
