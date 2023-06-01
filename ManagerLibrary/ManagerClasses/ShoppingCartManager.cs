using ClassLibrary.Classes.Item;
using ClassLibrary.Classes.User;
using InterfaceLibrary.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.ManagerClasses
{
    public class ShoppingCartManager
    {
        private readonly IShoppingRepository shoppingRepository;

        public ShoppingCartManager(IShoppingRepository shoppingRepository)
        {
            this.shoppingRepository = shoppingRepository;
        }



        public bool PlaceOrder(User user, List<Item> items, string address, double totalPrice)
        {
            return shoppingRepository.PlaceOrder(user, items, address, totalPrice);
        }
    }
}
