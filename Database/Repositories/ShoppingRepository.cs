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

        public bool PlaceOrder(User user, Item item, string address)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"INSERT INTO [Order] (id, item_id, quantity, total_price, shipping_address, date_time) " +
                           $"VALUES('{user.Id}', '{item.ItemId}', '{item.ItemQuantity}', '{null}', '{address}', '{DateTime.Now}'); " +
                           $"DECLARE @order_id int = SCOPE_IDENTITY(); " +
                           $"UPDATE Product SET quantity = CASE " +
                           $"WHEN quantity >= {item.ItemQuantity} THEN quantity - {item.ItemQuantity} " +
                           $"ELSE 0 " +
                           $"END " +
                           $"WHERE item_id = {item.ItemId};";

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
