using ClassLibrary.Classes.User;
using ManagerLibrary.ManagerClasses;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using UnitTest.TestData;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void TestGetUsers()
        {
            UserManager userManager = new(new FakeDataUser());

            List<User> returnedUsers = userManager.GetUsers();

            Assert.AreEqual(returnedUsers.Count, 4);
        }

        [TestMethod]
        public void TestGetUserById()
        {
            UserManager userManager = new(new FakeDataUser());

            int returnedUserId = userManager.GetUserById(1).Id;

            Assert.AreEqual(returnedUserId, 1);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetUserByIdFail()
        {
            UserManager userManager = new UserManager(new FakeDataUser());

            User user1 = userManager.GetUserById(12);
            User user2 = userManager.GetUsers()[12];

            Assert.AreEqual(user1, user2);
        }



        [TestMethod]
        public void TestGetUserByEmail()
        {
            UserManager userManager = new(new FakeDataUser());

            string testUserEmail = userManager.GetUserByEmail("test@user1").Email;

            Assert.AreEqual(testUserEmail, "test@user1");
        }


        [TestMethod]
        public void TestGetUserByEmail_WrongEmail()
        {
            UserManager userManager = new UserManager(new FakeDataUser());

            Assert.ThrowsException<NullReferenceException>(() => userManager.GetUserByEmail("wrongemail@example.com").Email);
        }


        [TestMethod]
        public void TestCreateUser()
        {
            FakeDataUser fakeDataUser = new FakeDataUser();
            var user = new User(5, "testUser5", "testUser5", "test@user5", "testuser5", UserType.Admin);

            var result = fakeDataUser.CreateUser(user);

            Assert.IsTrue(result);
            CollectionAssert.Contains(fakeDataUser.GetUsers(), user);
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            var fakeDataUser = new FakeDataUser();
            var updatedUser = new User(4, "updatedUser", "updatedUser", "updated@test.com", "updateduser", UserType.Admin);

            var result = fakeDataUser.UpdateUser(updatedUser);

            Assert.IsTrue(result);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUpdateUserFail()
        {
            var fakeDataUser = new FakeDataUser();
            User user = new User(8, "updatedUser", "updatedUser", "updated@test.com", "updateduser", UserType.Admin);
            User userList = fakeDataUser.GetUsers()[1];

            fakeDataUser.UpdateUser(user);

            Assert.AreNotEqual(userList, fakeDataUser.GetUsers()[3]);
        }


        [TestMethod]
        public void TestDeleteUser()
        {
            var fakeDataUser = new FakeDataUser();
            var user = new User(4, "testUser4", "testUser4", "test@user4", "testuser4", UserType.Admin);

            var result = fakeDataUser.DeleteUser(user);

            Assert.IsTrue(result);
            CollectionAssert.DoesNotContain(fakeDataUser.GetUsers(), user);
        }

        [TestMethod]
        public void SearchUsers()
        {
            var fakeDataUser = new FakeDataUser();
            var user1 = new User(1, "testUser1", "testUser1", "test@user1", "testuser1", UserType.Admin);
            var user2 = new User(2, "testUser2", "testUser2", "test@user2", "testuser2", UserType.Admin);
            var user3 = new User(3, "testUser3", "testUser3", "test@user3", "testuser3", UserType.Admin);
            var user4 = new User(4, "testUser4", "testUser4", "test@user4", "testuser4", UserType.Admin);

            var result = fakeDataUser.SearchUsers("testUser2");

            bool isUser2Found = result.Any(u => u.FirstName == user2.FirstName);
            Assert.IsTrue(isUser2Found);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestSearchUserFail()
        {
            var fakeDataUser = new FakeDataUser();

            var result = fakeDataUser.SearchUsers("nonexistentUser");

            Assert.AreEqual(0, result.Count);
        }

    }
}
