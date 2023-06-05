using ClassLibrary.Classes.Item;
using ClassLibrary.Classes.User;
using InterfaceLibrary.IRepositories;
using ManagerLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.Algorithm
{
    public class ShoppingCartAlgorithms
    {
        private readonly IUserRepository userRepository;
        public ShoppingCartAlgorithms(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public User GetUserFromAuthentication(string email)
        {
            User user = userRepository.GetUserByEmail(email); 
            return user;
        }
        public double CalculateTotalPrice(List<Item> items)
        {
            if (items == null || items.Count == 0)
            {
                return 0;
            }

            double totalPrice = 0;
            foreach (var item in items)
            {
                totalPrice += item.ItemPrice * item.ItemQuantity;
            }
            return totalPrice;
        }


        public static int ExistingItem(List<Item> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ItemId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
