using ClassLibrary.Classes.User;
using ManagerLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.ManagerClasses
{
    public class AuthenticationService
    {
        private UserRepository userRepository = new UserRepository();

        public AuthenticationService()
        { }

        //public bool Authenticate(string email, string password, out User authenticatedUser)
        //{
        //    authenticatedUser = null;
        //    User user = new User();
        //    user.Email = email;
        //    user.Password = password;
        //    bool result = userRepository.AuthenticateUser(user);

        //    if (result)
        //    {
        //        authenticatedUser = user;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public bool Login(string email, string password)
        //{
        //    if (userRepository.CheckLogin(email, password))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

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
