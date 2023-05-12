using ClassLibrary.Classes.User;
using ManagerLibrary.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace UnitTest
{
    [TestClass]
    public class UserRepositoryTests
    {
        private UserRepository userRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            userRepository = new UserRepository();
        }

        [TestMethod]
        public void GetUsers_ReturnsAllUsers()
        {
            List<User> expectedUsers = new List<User>()
            {
                new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com", Password = "password1", UserType = UserType.Customer } ,
                new User() { Id = 2, FirstName = "Jane", LastName = "Doe", Email = "janedoe@example.com", Password = "password2", UserType = UserType.Admin }
            };

            List<User> actualUsers = userRepository.GetUsers();

            CollectionAssert.AreEqual(expectedUsers, actualUsers);
        }
    }
}