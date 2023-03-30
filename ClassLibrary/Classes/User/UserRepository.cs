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
    }
}
