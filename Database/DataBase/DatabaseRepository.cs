using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Database.DataBase
{
    public abstract class DatabaseRepository<T> where T : Entity, new()
    {
        protected IEnumerable<PropertyInfo> properties;
        protected IEnumerable<PropertyInfo> propertiesWithoutID;
        protected string tableName;

        public DatabaseRepository()
        {
            this.properties = typeof(T).GetProperties();
            this.propertiesWithoutID = this.properties.Where(p => p.GetCustomAttribute<PrimaryKey>() == null);
            this.tableName = Helpers.ConvertPascalToSnake(typeof(T).Name);
        }

        protected SqlConnection Connect()
        {
            string ConnectionString = "Server=mssqlstud.fhict.local;Database=dbi500182;User Id=dbi500182;Password=123;";
            SqlConnection connection = new(ConnectionString);
            try { connection.Open(); }
            catch (SqlException ex)
            {
                throw ex.Number switch
                {
                    0 => new Exception("Cannot connect to server"),
                    1045 => new Exception("Invalid username/password provided"),
                    _ => new Exception("Something went wrong"),
                };
            }
            return connection;
        }
        public IEnumerable<T> ReadAll()
        {
            using SqlConnection connection = Connect();
            SqlCommand command = new($"SELECT * FROM {this.tableName}", connection);
            SqlDataReader reader = command.ExecuteReader();
            List<T> records = new();
            while (reader.Read())
                records.Add(Helpers.Serialize<T>(reader));
            reader.Close();
            return records;
        }
        public T? Read(int id)
        {
            using SqlConnection connection = Connect();
            SqlCommand command = new($"SELECT * FROM {this.tableName} WHERE id=@id", connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            T? record = default;
            if (reader.Read())
                record = Helpers.Serialize<T>(reader);
            reader.Close();
            return record;
        }

        public void Delete(int id)
        {
            using SqlConnection connection = Connect();
            SqlCommand command = new($"DELETE FROM {this.tableName} WHERE id=@id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public void Update(T record)
        {
            using SqlConnection connection = Connect();
            string clauses = string.Join(", ", this.propertiesWithoutID.Select(p => $"{Helpers.GetColumnName(p)} = @{Helpers.GetColumnName(p)}"));
            SqlCommand command = new($"UPDATE {this.tableName} SET {clauses} WHERE id=@id", connection);
            foreach (PropertyInfo property in this.properties)
            {
                var value = property.GetValue(record);

                command.Parameters.AddWithValue($"@{Helpers.GetColumnName(property)}", value.ToString());
            }
            command.ExecuteNonQuery();
        }

        public void Create(T record)
        {
            using SqlConnection connection = Connect();
            string columns = string.Join(", ", propertiesWithoutID.Select(p => p.GetCustomAttribute<ColumnName>()?.Name));
            string values = string.Join(", ", propertiesWithoutID.Select(p => "@" + p.Name));
            SqlCommand command = new($"INSERT INTO {this.tableName} ({columns}) VALUES ({values})", connection);
            command.ExecuteNonQuery();
        }
    }
}
