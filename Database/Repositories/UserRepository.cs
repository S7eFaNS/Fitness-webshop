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
                    $"user_type = {user.UserType}," +
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
                                user.UserType = Enum.Parse<UserType>((string)reader["user_type"]);
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

        public User GetUserByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                User user = new User();

                try
                {
                    connection.Open();
                    string query = $"SELECT * FROM Users " +
                        $"WHERE email = '{email}'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user.Id = reader.GetInt32(0);
                                user.FirstName = reader.GetString(1);
                                user.LastName = reader.GetString(2);
                                user.Email = reader.GetString(3);
                                user.Password = reader.GetString(4);
                                user.UserType = (UserType)Enum.Parse(typeof(UserType), reader.GetString(5));
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

        public bool CreateAdmin(Admin admin)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"INSERT INTO Admins (id) " +
                        $"VALUES('{admin.Id}')";

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

        public bool DeleteAdmin(Admin admin)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"DELETE FROM Admins WHERE id = {admin.Id};";

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

        public Admin GetAdminById(int adminId)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                Admin admin = new Admin();
                try
                {
                    connection.Open();
                    string query = $"SELECT Users.id, Users.email, Users.first_name, Users.last_name" +
                        $"FROM Users " +
                        $"INNER JOIN Admins ON Users.id = Admins.id " +
                        $"WHERE Users.id = {adminId}";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                admin.Id = reader.GetInt32(0);
                                admin.FirstName = reader.GetString(1);
                                admin.LastName = reader.GetString(2);
                                admin.Email = reader.GetString(3);
                            }
                        }
                    }
                    return admin;
                }
                catch (Exception ex)
                {
                    return admin;
                }
            }
        }

        public List<Admin> GetAdmins()
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                List<Admin> admins = new List<Admin>();

                try
                {
                    connection.Open();
                    string query = $"SELECT Users.id, Users.email, Users.first_name, Users.last_name" +
                        $"FROM Users " +
                        $"INNER JOIN Admins ON Users.id = Admins.id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Admin admin = new Admin();

                                admin.Id = reader.GetInt32(0);
                                admin.FirstName= reader.GetString(1);
                                admin.LastName= reader.GetString(2);
                                admin.Email = reader.GetString(3);

                                admins.Add(admin);
                            }
                        }
                    }
                    return admins;
                }
                catch (Exception ex)
                {
                    return admins;
                }
            }
        }

        public bool CreateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"INSERT INTO Customers(id, age) " +
                        $"VALUES('{customer.Id}', '{customer.Age}')";

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

        public bool UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"UPDATE Customers " +
                    $"SET age = '{customer.Age}', " +
                    $"WHERE id = {customer.Id};";

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

        public bool DeleteCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"DELETE FROM Customers WHERE id = {customer.Id};";

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

        public Customer GetCustomerById(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                Customer customer = new Customer();

                try
                {
                    connection.Open();
                    string query = $"SELECT Users.id, Users.first_name, Users.last_name, Users.email, Customers.age" +
                        $"FROM Users " +
                        $"INNER JOIN Customers ON Users.id = {customerId}; ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.Id = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Email = reader.GetString(3);
                                customer.Age = reader.GetInt32(4);
                            }
                        }
                    }
                    return customer;
                }
                catch (Exception ex)
                {
                    return customer;
                }
            }
        }

        public List<Customer> GetCustomers()
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                List<Customer> customers = new List<Customer>();

                try
                {
                    connection.Open();
                    string query = $"SELECT Users.id, Users.first_name, Users.last_name, Users.email, Visitors.age" +
                        $"FROM Users " +
                        $"INNER JOIN Customers ON Users.id = Customers.id; ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();

                                customer.Id = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Email = reader.GetString(3);
                                customer.Age = reader.GetInt32(4);

                                customers.Add(customer);
                            }
                        }
                    }
                    return customers;
                }
                catch (Exception ex)
                {
                    return customers;
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
                                UserType = Enum.Parse<UserType>((string)reader["user_type"])
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
