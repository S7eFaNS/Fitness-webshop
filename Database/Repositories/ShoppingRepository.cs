using ClassLibrary.Classes.Item;
using ClassLibrary.Classes.User;
using Database.DataBase;
using InterfaceLibrary.IRepositories;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class ShoppingRepository : IShoppingRepository
    {
        private string _ConnectionString;

        public ShoppingRepository()
        {
            ConfigureService();
        }
        private void ConfigureService()
        {
            DataBaseConnection dbConn = new DataBaseConnection();
            _ConnectionString = dbConn.ConnectionString;
        }

        public List<int> GetPurchasedItemIdsByUser(int userId)
        {
            List<int> itemIds = new List<int>();

            using (SqlConnection connection= new SqlConnection( _ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT item_id FROM UserItem WHERE user_id = @user_id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@user_id", userId);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int itemId = reader.GetInt32(0);
                                itemIds.Add(itemId);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Unable to retrieve user's purchases!");
                }
            }
            return itemIds;
        }

        public bool PlaceOrder(User user, List<Item> items, string address, double totalPrice)
        { 

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();

                    string queryFirst = "INSERT INTO UserItem (user_id, item_id) " +
                        "VALUES (@user_id, @item_id); " +
                        "DECLARE @id int = SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(queryFirst, connection))
                    {
                        command.Parameters.AddWithValue("@user_id", user.Id);

                        for (int i = 0; i < items.Count; i++)
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@user_id", user.Id);
                            command.Parameters.AddWithValue("@item_id", items[i].ItemId);
                            command.ExecuteNonQuery();
                        }
                    }

                    string querySecond = "DECLARE @order_id int; " +
                        "INSERT INTO [Order] (id, item_id, quantity, total_price, shipping_address, date_time) " +
                        "VALUES (@id, @item_id, @quantity, @total_price, @shipping_address, @date_time); " +
                        "SET @order_id = SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(querySecond, connection))
                    {
                        var date = DateTime.Now;

                        command.Parameters.AddWithValue("@id", user.Id);
                        command.Parameters.AddWithValue("@total_price", totalPrice);
                        command.Parameters.AddWithValue("@shipping_address", address);
                        command.Parameters.AddWithValue("@date_time", date);

                        for (int i = 0; i < items.Count; i++)
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@id", user.Id);
                            command.Parameters.AddWithValue("@total_price", totalPrice);
                            command.Parameters.AddWithValue("@shipping_address", address);
                            command.Parameters.AddWithValue("@date_time", date);
                            command.Parameters.AddWithValue("@item_id", items[i].ItemId);
                            command.Parameters.AddWithValue("@quantity", items[i].ItemQuantity);
                            command.ExecuteNonQuery();
                        }
                    }

                    string queryThird =  
                           $"UPDATE Product SET item_quantity = CASE " +
                           $"WHEN item_quantity >= @item_quantity THEN item_quantity - @item_quantity " +
                           $"ELSE 0 " +
                           $"END " +
                           $"WHERE item_id = @item_id;";
                    using (SqlCommand command = new SqlCommand(queryThird, connection))
                    {
                        for(int i = 0; i < items.Count; i++)
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@item_quantity", items[i].ItemQuantity);
                            command.Parameters.AddWithValue("@item_id", items[i].ItemId);
                            command.ExecuteNonQuery();
                        }
                    }
                    connection.Close();

                    return true;
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occured when trying to place the order!");
                }
            }
        }
    }
}
