using ClassLibrary.Classes.User;
using InterfaceLibrary.IManagers;
using InterfaceLibrary.IRepositories;
using ManagerLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.ManagerClasses
{
    public class AuthenticationService /*: IAuthenticationService*/
    {
        private readonly IUserRepository repository;

        public AuthenticationService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public User? CheckLogin(string email, string password) => repository.CheckLogin(email, password);

        public bool Register(Customer customer)
        {
            return repository.CreateUser(customer);
        }
    }
}
