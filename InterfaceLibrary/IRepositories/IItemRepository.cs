using ClassLibrary.Classes.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.IRepositories
{
    public interface IItemRepository
    {
        List<Item> GetItems();
        bool CreateItem(Item item);
        bool UpdateItem(Item item);
        bool DeleteItem(Item item);
        Item GetItemById(int id);
        List<Item> SearchItems(string searchQuery);
    }
}
