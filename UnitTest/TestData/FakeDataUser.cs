using ClassLibrary.Classes.User;
using InterfaceLibrary.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.TestData
{
    public class FakeDataUser : IUserRepository
    {
        private readonly List<User> users;

        public FakeDataUser()
        {
            users = new List<User>()
            {
                new User(1, "testUser1", "testUser1", "test@user1", "testuser1", UserType.Admin),
                new User(2, "testUser2", "testUser2", "test@user2", "testuser2", UserType.Admin),
                new User(3, "testUser3", "testUser3", "test@user3", "testuser3", UserType.Admin),
                new User(4, "testUser4", "testUser4", "test@user4", "testuser4", UserType.Admin)
            };
        }

        public List<User> GetUsers() {
            return users; 
        }

        public bool CreateUser(User user)
        {
            users.Add(user);
            return users.Count > 4;

        }

        public bool DeleteUser(User user)
        {
            int index = users.FindIndex(u => u.Id == user.Id);
            if (index >= 0)
            {
                users.RemoveAt(index);
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool UpdateUser(User user)
        {
            int index = users.FindIndex(u => u.Id == user.Id);
            if (index >= 0)
            {
                users[index] = user;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index not found");
            }
            return true;
        }

        public User? GetUserById(int id)
        {
            return users.Find(u => u.Id == id);
        }

        public User? GetUserByEmail(string email)
        {
            return users.Find(u => u.Email == email);
        }

        public List<User> SearchUsers(string searchQuery)
        {
            List<User> foundUsers = new();
            foreach(var user in users)
            {
                if (user.Email.Contains(searchQuery) || 
                    user.Id.ToString().Contains(searchQuery) || 
                    user.FirstName.Contains(searchQuery) ||
                    user.LastName.Contains(searchQuery))
                {
                    foundUsers.Add(user);
                }
            }
            if (foundUsers.Count == 0)
            {
                throw new Exception("No items found matching the search criteria.");
            }
            return foundUsers;
        }

        public string GetSalt(string email)
        {
            throw new NotImplementedException();
        }

        public User? CheckLogin(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
