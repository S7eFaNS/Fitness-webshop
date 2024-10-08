﻿using ClassLibrary.Classes.Item;
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
                                    ItemPrice = Convert.ToInt32(reader.GetDecimal(2)),
                                    ItemDescription = reader.GetString(3),
                                    ItemQuantity = reader.GetInt32(4),
                                    ItemType = (ItemType)Enum.Parse(typeof(ItemType), reader.GetString(5))
                                };
                                items.Add(item);
                            };
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("No items found.");
                }
            }
            return items;
        }

        public List<Item> GetSupplements()
        {
            List<Item> supplements = new List<Item>();
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"SELECT * FROM [Product] WHERE item_type = '{ItemType.Supplement}';" ;

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Item supplement = new Item()
                                {
                                    ItemId = reader.GetInt32(0),
                                    ItemName = reader.GetString(1),
                                    ItemPrice = Convert.ToInt32(reader.GetDecimal(2)),
                                    ItemDescription = reader.GetString(3),
                                    ItemQuantity = reader.GetInt32(4),
                                    ItemType = (ItemType)Enum.Parse(typeof(ItemType), reader.GetString(5))
                                };
                                supplements.Add(supplement);
                            };
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("No supplements found.");
                }
            }
            return supplements;
        }

        public List<Item> GetPrograms()
        {
            List<Item> programs = new List<Item>();
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"SELECT * FROM [Product] WHERE item_type = '{ItemType.Program}';";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Item program = new Item()
                                {
                                    ItemId = reader.GetInt32(0),
                                    ItemName = reader.GetString(1),
                                    ItemPrice = Convert.ToInt32(reader.GetDecimal(2)),
                                    ItemDescription = reader.GetString(3),
                                    ItemQuantity = reader.GetInt32(4),
                                    ItemType = (ItemType)Enum.Parse(typeof(ItemType), reader.GetString(5))
                                };
                                programs.Add(program);
                            };
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("No programs found.");
                }
            }
            return programs;
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

                    if (item is Programs program)
                    {
                        query += $"INSERT INTO [Program] (item_id, program_link) VALUES (@ItemId, '{program.ProgramLink}'); ";
                    }
                    else if (item is Supplement supplement)
                    {
                        query += $"INSERT INTO [Supplement] (item_id) VALUES (@ItemId); ";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (SqlException ex)
                {
                    throw new Exception("The item was not created!");

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

                    if (item is Programs)
                    {
                        Programs program = (Programs)item;
                        query = $"UPDATE [Program] " +
                                $"SET program_link = '{program.ProgramLink}' " +
                                $"WHERE item_id = {program.ItemId};";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    return true;
                }
                catch (SqlException ex)
                {
                    throw new Exception("There was a problem when editing the item");
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
                catch (SqlException ex)
                {
                    throw new Exception("An error occured when trying to delete the item!");
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
                                item.ItemPrice = Convert.ToDouble(reader["item_price"]);
                                item.ItemDescription = (string)reader["item_description"];
                                item.ItemQuantity = (int)reader["item_quantity"];
                                item.ItemType = Enum.Parse<ItemType>((string)reader["item_type"]);
                            }
                        }
                    }

                    if (item.ItemType == ItemType.Program)
                    {
                        query = $"SELECT [Product].*, Program.program_link FROM Product INNER JOIN Program ON [Product].item_id = Program.item_id WHERE [Product].item_id = {id}";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    item = new Programs();
                                    string programLink = (string)reader["program_link"];
                                    ((Programs)item).ProgramLink = programLink;
                                }
                                    item.ItemId = (int)reader["item_id"];
                                    item.ItemName = (string)reader["item_name"];
                                    item.ItemPrice = Convert.ToDouble(reader["item_price"]);
                                    item.ItemDescription = (string)reader["item_description"];
                                    item.ItemQuantity = (int)reader["item_quantity"];
                                    item.ItemType = Enum.Parse<ItemType>((string)reader["item_type"]);
                            }
                        }
                    }
                    return item;
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occured trying to retrieve the item's information!");
                }
            }
        }
        public List<Item> SearchItems(string searchQuery)
        {
            List<Item> matchedItems = new List<Item>();

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"SELECT * FROM [Product] " +
                        $"WHERE item_id LIKE '%{searchQuery}%' OR " +
                        $"item_name LIKE '%{searchQuery}%' OR " +
                        $"item_price LIKE '%{searchQuery}%'";

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
                                    ItemPrice = Convert.ToInt32(reader.GetDecimal(2)),
                                    ItemDescription = reader.GetString(3),
                                    ItemQuantity = reader.GetInt32(4),
                                    ItemType = (ItemType)Enum.Parse(typeof(ItemType), reader.GetString(5))
                                };
                                matchedItems.Add(item);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("There were no items found!");
                }
            }
            return matchedItems;
        }
    }
}