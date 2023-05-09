using ClassLibrary.Classes.Item;
using ClassLibrary.Classes.User;
using Database.DataBase;
using InterfaceLibrary.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.Repositories
{
    public class ItemRepository : IItemRepository 
    {

        private string _ConnectionString;

        public ItemRepository()
        {
            ConfigureService();
        }

        private void ConfigureService()
        {
            DataBaseConnection dbConn = new DataBaseConnection();
            _ConnectionString = dbConn.ConnectionString;
        }

        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM [Product]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Item item = new Item()
                                {
                                    ItemId = reader.GetInt32(0),
                                    ItemName = reader.GetString(1),
                                    ItemPrice = Convert.ToDouble(reader.GetString(2)),
                                    ItemDescription = reader.GetString(3),
                                    ItemQuantity = Convert.ToInt32(reader.GetString(4)),
                                    ItemType = (ItemType)Enum.Parse(typeof(ItemType), reader.GetString(5))
                                };
                                items.Add(item);
                            };

                        }
                    }
                }
                catch (Exception ex)
                {
                    return items;
                }
            }
            return items;
        }

        public bool CreateItem(Item item)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"INSERT INTO [Product] (item_name, item_price, item_description, item_quantity, item_type) " +
                                   $"VALUES('{item.ItemName}', '{item.ItemPrice}', '{item.ItemDescription}', '{item.ItemQuantity}', '{item.ItemType}'); " +
                                   $"DECLARE @ItemId int = SCOPE_IDENTITY(); ";

                    if (item is Program program)
                    {
                        query += $"INSERT INTO [Program] (item_id, program_link) VALUES (@ItemId, {program.ProgramLink});";
                    }
                    else if (item is Supplement supplement)
                    {
                        query += $"INSERT INTO [Supplement] (item_id) VALUES (@ItemId);";
                    }

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

        public bool UpdateItem(Item item)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query;

                    query = $"UPDATE [Product] " +
                        $"SET item_name = '{item.ItemName}', " +
                        $"item_price = '{item.ItemPrice}', " +
                        $"item_description = '{item.ItemDescription}', " +
                        $"item_quantity = '{item.ItemQuantity}' " +
                        $"WHERE item_id = {item.ItemId};";



                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    if (item is Program)
                    {
                        Program program = (Program)item;
                        query = $"UPDATE [Program] " +
                                $"SET program_link = {program.ProgramLink} " +
                                $"WHERE item_id = {program.ItemId};";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool DeleteItem(Item item)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"DELETE FROM [Product] WHERE item_id = {item.ItemId};";

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

        public Item? GetItemById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                Item? item = null;
                try
                {
                    connection.Open();

                    string query = $"SELECT * FROM [Product] WHERE item_id={id}";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                item = new Item();
                                item.ItemId = (int)reader["item_id"];
                                item.ItemName = (string)reader["item_name"];
                                item.ItemPrice = (double)reader["item_price"];
                                item.ItemDescription = (string)reader["item_description"];
                                item.ItemQuantity = (int)reader["item_quantity"];
                                item.ItemType = Enum.Parse<ItemType>((string)reader["item_type"]);
                            }
                        }
                    }

                    return item;
                }
                catch (Exception ex)
                {
                    return item;
                }
            }
        }

    }
}