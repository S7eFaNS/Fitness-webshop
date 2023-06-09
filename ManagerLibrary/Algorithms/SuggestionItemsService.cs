using ClassLibrary.Classes.Item;
using InterfaceLibrary.IAlgorithmService;
using InterfaceLibrary.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.Algorithms
{
    public class SuggestionItemsService : ISuggestionItemService
    {
        private readonly IUserRepository userRepository;
        private readonly IItemRepository itemRepository;
        private readonly IShoppingRepository shoppingRepository;

        public SuggestionItemsService(IUserRepository userRepository, IItemRepository itemRepository, IShoppingRepository shoppingRepository)
        {
            this.userRepository = userRepository;
            this.itemRepository = itemRepository;
            this.shoppingRepository = shoppingRepository;
        }

        public List<Item> GetProductSuggestions(int userId)
        {
            List<Item> allItems = itemRepository.GetItems();

            List<int> userPurchasedItemIds = shoppingRepository.GetPurchasedItemIdsByUser(userId);

            Dictionary<int, int> itemCounts = new Dictionary<int, int>();

            foreach (int itemId in userPurchasedItemIds)
            {
                if (itemCounts.ContainsKey(itemId))
                {
                    itemCounts[itemId]++;
                }
                else
                {
                    itemCounts[itemId] = 1;
                }
            }

            List<Item> suggestedItems = itemCounts.OrderByDescending(x => x.Value)
                                        .Select(x => allItems.FirstOrDefault(item => item.ItemId == x.Key))
                                        .ToList();

            return suggestedItems;
        }
    }
}
