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
    public class AuthenticationService : IAuthenticationService
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





        //public bool RegisterVisitor(string firstName, string lastName, string email, string password, string roleString, int age, string imageUrl)
        //{
        //    if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        //    {
        //        return false;
        //    }

        //    UserType role = Enum.TryParse<UserType>(roleString, out UserType parsedRole) ? parsedRole : UserType.Organizer;
        //    User user = new User(0, firstName, lastName, email, password, role);

        //    if (userRepository.CreateUser(user))
        //    {
        //        User createdUser = userRepository.GetUserByEmail(email);
        //        Customer visitor = new Customer(id, firstName, lastName, email, password, userType);

        //        return userRepository.CreateVisitor(visitor);
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
