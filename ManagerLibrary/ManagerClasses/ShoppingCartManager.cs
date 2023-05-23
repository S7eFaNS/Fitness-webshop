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

        public bool PlaceOrder(User user, Item item, string address)
        {
            return shoppingRepository.PlaceOrder(user, item, address);
        }
    }
}
