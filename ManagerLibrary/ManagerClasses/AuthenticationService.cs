using ClassLibrary.Classes.User;
using GymProject.ViewModels;
using InterfaceLibrary.IRepositories;
using ManagerLibrary.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.ManagerClasses
{
    public class AuthenticationService
    {
        private readonly IUserRepository repository;

        public AuthenticationService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public User? CheckLogin(string email, string password) => repository.CheckLogin(email, password);

        public bool Register(UserRegistrationModel registrationModel)
        {            
            Customer customer = registrationModel.ToCustomer();

            bool emailExists = CheckUserByEmail(customer.Email);
            if (emailExists)
            {
                return false;
            }

            return repository.CreateUser(customer);
        }

        public bool CheckUserByEmail(string email)
        {
            User existingUser = repository.GetUserByEmail(email);
            return existingUser != null;
        }

    }
}
