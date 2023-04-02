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

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Id, first_name, last_name, email FROM Users";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User()
                                {
                                    Id = reader.GetInt32(0),
                                    GetFirstName = reader.GetString(1),
                                    GetLastName = reader.GetString(2),
                                    GetEmail = reader.GetString(3),
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

        public bool DeleteUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"DELETE FROM Users WHERE Id = {user.Id};";

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
    }
}
