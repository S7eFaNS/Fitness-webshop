using ClassLibrary.Classes.Item;
using ClassLibrary.Classes.User;
using InterfaceLibrary.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.Algorithm
{
    public class Algorithm
    {
        private readonly IUserRepository userRepository;
        private readonly IItemRepository itemRepository;
        private readonly IShoppingRepository shoppingRepository;
        public Algorithm(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Algorithm(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public Algorithm(IShoppingRepository shoppingRepository)
        {
            this.shoppingRepository = shoppingRepository;
        }

        public List<Item> GetPurchasedItemsByUser(int userId)
        {
            List<int> itemIds = shoppingRepository.GetPurchasedItemIdsByUser(userId);

            List<Item> purchasedItems = new List<Item>();
            foreach (int itemId in itemIds)
            {
                Item item = itemRepository.GetItemById(itemId);
                if (item != null)
                {
                    purchasedItems.Add(item);
                }
            }
            return purchasedItems;
        }

        public List<Item> GetProductSuggestions(int userId)
        {
            List<User> users = userRepository.GetUsers();

            List<int> currentUserProductIds = shoppingRepository.GetPurchasedItemIdsByUser(userId);
            List<Item> suggestedItems = new List<Item>();

            foreach(User user in users)
            {
                List<int> userProductIds = shoppingRepository.GetPurchasedItemIdsByUser(user.Id);
                double similarity = CalculateCosineSimilarity(currentUserProductIds, userProductIds);

                if(similarity > 0.0)
                {
                    List<Item> itemsPurchasedByUser = GetPurchasedItemsByUser(user.Id);
                    foreach(Item item in itemsPurchasedByUser)
                    {
                        if(!currentUserProductIds.Contains(item.ItemId) && !suggestedItems.Contains(item))
                        {
                            suggestedItems.Add(item);
                        }
                    }
                }
            }
            return suggestedItems;
        }

        private double CalculateCosineSimilarity(List<int> user1Products, List<int> user2Products)
        {
            HashSet<int> commonProducts = new HashSet<int>(user1Products);
            commonProducts.IntersectWith(user2Products);

            if (commonProducts.Count == 0)
            {
                return 0.0;
            }

            double dotProduct = commonProducts.Count;

            double user1Norm = Math.Sqrt(user1Products.Count);
            double user2Norm = Math.Sqrt(user2Products.Count);

            return dotProduct / (user1Norm + user2Norm);
        }

    }
}
