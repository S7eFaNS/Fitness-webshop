﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes
{
    public class Customer : User
    {
        public Customer(string name, string password, string email) : base(name, password, email)
        {

        }
    }
}
