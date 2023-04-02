using Database.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.User
{
    public class UserRepository : DatabaseRepository<User>
    {
        public List<User> ReadAll(string name)
        {
            using SqlConnection connection = Connect();
            SqlCommand command = new($"SELECT * FROM {this.tableName} WHERE first_name LIKE @name OR last_name LIKE @name", connection);
            command.Parameters.AddWithValue("@name", $"%{name}%");
            SqlDataReader reader = command.ExecuteReader();
            List<User> records = new();
            while (reader.Read())
                records.Add(Helpers.Serialize<User>(reader));
            reader.Close();
            return records;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi500182;User Id=dbi500182;Password=123;"))
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
            using (SqlConnection connection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi500182;User Id=dbi500182;Password=123;"))
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
