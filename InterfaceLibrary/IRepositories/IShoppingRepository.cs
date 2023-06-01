using ClassLibrary.Classes.Item;
using ClassLibrary.Classes.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.IRepositories
{
    public interface IShoppingRepository
    {
        bool PlaceOrder(User user, List<Item> items, string address, double totalPrice);

        List<int> GetPurchasedItemIdsByUser(int userId);
    }
}
