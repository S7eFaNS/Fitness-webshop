using ClassLibrary.Classes.User;
using Database.DataBase;
using InterfaceLibrary.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.Repositories
{
    public class UserRepository : IUserRepository
    {
        private string _ConnectionString;

        public UserRepository()
        {
            ConfigureService();
        }

        private void ConfigureService()
        {
            DataBaseConnection dbConn = new DataBaseConnection();
            _ConnectionString = dbConn.ConnectionString;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM [User]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User()
                                {
                                    Id = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    Password = reader.GetString(4),
                                    UserType = (UserType)Enum.Parse(typeof(UserType), reader.GetString(5))
                                };
                                users.Add(user);
                            };

                        }
                    }
                }
                catch (SqlException e)
                {
                    throw new Exception("An error occurred while fetching users.");
                }
            }
            return users;
        }

        public bool CreateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();

                    string randomSalt = BCrypt.Net.BCrypt.GenerateSalt();
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password, randomSalt);
                    user.Password = hashedPassword;

                    string query = $"INSERT INTO [User] (first_name, last_name, email, password, user_type, password_salt) " +
                                   $"VALUES('{user.FirstName}', '{user.LastName}', '{user.Email}', '{hashedPassword}', '{user.UserType/*(user is Customer ?  user.UserType = UserType.Customer : user.UserType = UserType.Admin)*/  }', '{randomSalt}'); " +
                                   $"DECLARE @UserID int = SCOPE_IDENTITY(); ";

                    if (user is Customer customer)
                    {
                        query += $"INSERT INTO [Customer] (id, age) VALUES (@UserID, {customer.Age});";
                    }
                    else if(user is Admin admin)
                    {
                        query += $"INSERT INTO [Admin] (id) VALUES (@UserID);";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Account creation was unsuccessful!");
                }
            }
        }
        public bool UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query;
                  
                        query = $"UPDATE [User] " +
                            $"SET first_name = '{user.FirstName}', " +
                            $"last_name = '{user.LastName}', " +
                            $"email = '{user.Email}' " +
                            $"WHERE id = {user.Id};";
                    
                    

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    if (user is Customer)
                    {
                        Customer customer = (Customer)user;
                        query = $"UPDATE [Customer] " +
                                $"SET age = {customer.Age} " +
                                $"WHERE id = {customer.Id};";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    return true;
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occured and the account was not edited.");
                }
            }
        }
        public bool DeleteUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"DELETE FROM [User] WHERE id = {user.Id};";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Failed to delete user!");
                }
            }
        }
        public User? GetUserById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                User? user = null;
                try
                {
                    connection.Open();

                    string query = $"SELECT * FROM [User] WHERE id={id}";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User();
                                user.Id = (int)reader["Id"];
                                user.FirstName = (string)reader["first_name"];
                                user.LastName = (string)reader["last_name"];
                                user.Email = (string)reader["email"];
                                user.Password = (string)reader["password"];
                                user.UserType = Enum.Parse<UserType>((string)reader["user_type"]);
                            }
                        }
                    }

                    if (user.UserType == UserType.Customer)
                    {
                        query = $"SELECT [User].*, Customer.age FROM [User] INNER JOIN Customer ON [User].id = Customer.id WHERE [User].id = {id}";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    user = new Customer();
                                    int age = (int)reader["age"];
                                    ((Customer)user).Age = age;
                                }
                                user.Id = (int)reader["Id"];
                                user.FirstName = (string)reader["first_name"];
                                user.LastName = (string)reader["last_name"];
                                user.Email = (string)reader["email"];
                                user.Password = (string)reader["password"];
                                user.UserType = Enum.Parse<UserType>((string)reader["user_type"]);
                            }
                        }
                    }

                    return user;
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occured when trying to retrieve user's information");
                }
            }
        }

        public User GetUserByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                User? user = null;

                try
                {
                    connection.Open();
                    string query = $"SELECT * FROM [User] WHERE email=@Email";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User();
                                user.Id = (int)reader["Id"];
                                user.FirstName = (string)reader["first_name"];
                                user.LastName = (string)reader["last_name"];
                                user.Email = (string)reader["email"];
                                user.Password = (string)reader["password"];
                                user.UserType = Enum.Parse<UserType>((string)reader["user_type"]);
                            }
                        }
                    }
                    return user;
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occured when trying to retrieve user's information");
                }
            }
        }

        public List<User> SearchUsers(string searchQuery)
        {
            List<User> matchedUsers = new List<User>();

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"SELECT * FROM [User] " +
                        $"WHERE id LIKE '%{searchQuery}%' OR " +
                        $"first_name LIKE '%{searchQuery}%' OR " +
                        $"last_name LIKE '%{searchQuery}%' OR " +
                        $"email LIKE '%{searchQuery}%'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User
                                {
                                    Id = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    Password = reader.GetString(4),
                                    UserType = (UserType)Enum.Parse(typeof(UserType), reader.GetString(5))
                                };
                                matchedUsers.Add(user);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("No results found!");
                }
            }
            return matchedUsers;
        }

        public string GetSalt(string email)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT password_salt FROM [User] WHERE email = @email", connection);
                    cmd.Parameters.AddWithValue("@email", email);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetString("password_salt");
                    }
                    else
                    {
                        return String.Empty;
                    }
                }
                catch (SqlException)
                {
                    return String.Empty;
                }
            }
        }

            public User? CheckLogin(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                 try
                {
                    string salt = GetSalt(email);
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

                    connection.Open();
                    string query = $"SELECT * FROM [User] " +
                        $"WHERE email = '{email}' AND password = '{hashedPassword}'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User() { 
                                Id = (int)reader["Id"],
                                FirstName = (string)reader["first_name"],
                                LastName = (string)reader["last_name"],
                                Email = (string)reader["email"],
                                Password = (string)reader["password"],
                                UserType = Enum.Parse<UserType>((string)reader["user_type"])
                                };
                            }
                        }
                    }

                    return null;
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occured when trying to log in!");
                }
            }
        }
    }
}
