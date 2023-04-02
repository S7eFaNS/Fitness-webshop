using ClassLibrary.Classes.Item;
using Database.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    public class ItemSupplementRepository : DatabaseRepository<Supplement>
    {
        public Item? Read(string name)
        {
            using SqlConnection connection = this.Connect();
            SqlCommand command = new($"SELECT * FROM {this.tableName} WHERE name=@name", connection);
            command.Parameters.AddWithValue("@name", name);
            SqlDataReader reader = command.ExecuteReader();
            Item? record = null;
            while (reader.Read())
                record = Helpers.Serialize<Supplement>(reader);
            reader.Close();
            return record;
        }
        public List<Item> ReadAll(string name)
        {
            using SqlConnection connection = Connect();
            SqlCommand command = new($"SELECT * FROM {this.tableName} WHERE name LIKE @name OR id LIKE @id", connection);
            command.Parameters.AddWithValue("@name", $"%{name}%");
            command.Parameters.AddWithValue("@id", $"%{name}%");
            SqlDataReader reader = command.ExecuteReader();
            List<Item> records = new();
            while (reader.Read())
                records.Add(Helpers.Serialize<Supplement>(reader));
            reader.Close();
            return records;
        }
        //public List<Item> ReadAll()
        //{
        //    using SqlConnection connection = Connect();
        //    SqlCommand command = new($"SELECT * FROM {this.tableName}", connection);
        //    SqlDataReader reader = command.ExecuteReader();
        //    List<Item> records = new List<Item>();
        //    while (reader.Read())
        //    {
        //        bool isSupplement = (bool)reader["is_supplement"];
        //        if (isSupplement)
        //        {
        //            Supplement supplement = new Supplement()
        //            {
        //                Id = (int)reader["id"],
        //                Name = (string)reader["name"],
        //                Price = (double)reader["price"],
        //                Description = (string)reader["description"],
        //                Quantity = (double)reader["quantity"],
        //                IsSupplement = true
        //            };
        //            records.Add(supplement);
        //        }
        //        else
        //        {
        //            Program program = new Program()
        //            {
        //                Id = (int)reader["id"],
        //                Name = (string)reader["name"],
        //                Price = (double)reader["price"],
        //                Description = (string)reader["description"],
        //                Quantity = (double)reader["quantity"],
        //                IsSupplement = false
        //            };
        //            records.Add(program);
        //        }
        //    }
        //    reader.Close();
        //    return records;
        //}
    }
}
