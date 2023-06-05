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
        public User GetUserFromAuthentication(int userId)
        {
            User user = userRepository.GetUserById(userId); 
            return user;
        }
        public double CalculateTotalPrice(List<Item> items)
        {
            // Example: Calculate the total price based on the items
            // Replace this with your own code to calculate the total price
            double totalPrice = 0;
            foreach (var item in items)
            {
                totalPrice += item.ItemPrice;
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
