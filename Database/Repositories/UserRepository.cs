using ClassLibrary.Classes.User;
using Database.DataBase;
using InterfaceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        //public List<User> GetUsers()
        //{
        //    List<User> users = new List<User>();

        //    using (SqlConnection connection = new SqlConnection(_ConnectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            string query = "SELECT * FROM Users";

        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        User user = new User()
        //                        {
        //                            Id = reader.GetInt32(0),
        //                            GetFirstName = reader.GetString(1),
        //                            GetLastName = reader.GetString(2),
        //                            GetEmail = reader.GetString(3),
        //                            GetPassword= reader.GetString(4),
        //                            GetUserType = (UserType)Enum.Parse(typeof(UserType), reader.GetString(5))
        //                        };
        //                        users.Add(user);
        //                    };

        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return users;
        //        }
        //    }

        //    return users;
        //}
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Users";

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
                catch (Exception ex)
                {
                    return users;
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
                    string query = $"INSERT INTO Users(first_name, last_name, email, password, user_type)" +
                        $"VALUES('{user.FirstName}', '{user.LastName}', '{user.Email}', {user.Password}, '{user.UserType}', {(int)user.UserType}')";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
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
                    string query = $"UPDATE Users " +
                    $"SET first_name = '{user.FirstName}'," +
                    $"last_name = '{user.LastName}'," +
                    $"email = '{user.Email}'," +
                    $"password = {user.Password}," +
                    $"user_type = {(int)user.UserType}," +
                    $"WHERE id = {user.Id};";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
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
                    string query = $"DELETE FROM Users WHERE id = {user.Id};";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }

        public User? GetUserById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                User user = new();
                try
                {
                    connection.Open();

                    string query = $"SELECT * FROM Users WHERE id={id}";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user.Id = (int)reader["Id"];
                                user.FirstName = (string)reader["first_name"];
                                user.LastName = (string)reader["last_name"];
                                user.Email = (string)reader["email"];
                                user.Password = (string)reader["password"];
                                user.UserType = (UserType)Convert.ToInt32(reader["user_type"]);
                            }
                        }
                    }

                    return user;
                }
                catch (Exception ex)
                {
                    return user;
                }
            }
        }
        public User? CheckLogin(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                 try
                {
                    connection.Open();

                    string query = $"SELECT * FROM Users " +
                        $"WHERE email = '{email}' AND password = '{password}'";

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
                                UserType = (UserType)Convert.ToInt32(reader["user_type"])
                                    };
                            }
                        }
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
