using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes
{
    public class Admin : User
    {
        public Admin(string name, string password, string email) : base(name, password, email)
        {
             
        }
    }
}
