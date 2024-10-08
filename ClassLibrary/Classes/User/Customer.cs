﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.User
{
    public class Customer : User
    {
        public int Age { get; set; }

        public Customer() 
        {
            UserType = UserType.Customer;
        }

        public Customer(int id, string firstName, string lastName, string email, string password, int age)
        : base(id, firstName, lastName, email, password, UserType.Customer)
        {
            Age = age;
        }

        //public Customer(int id, string firstName, string lastName, int age, string email, string password, UserType userType)
        //{
        //    Id = id;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Age = age;
        //    Email = email;
        //    Password = password;
        //    UserType = UserType.Customer;
        //}
    }
}
