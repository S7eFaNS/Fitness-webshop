using ClassLibrary.Classes.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.IManagers
{
    public interface IItemManager
    {
        public List<Item> GetItems();
        public Item GetItemsById(int id);
        public bool CreateItem(Item item);
        public bool UpdateItem(Item item);
        public bool DeleteItem(int id);

        //public void AddItem(Item item);

        //public void RemoveItem(int itemId);

        //public void UpdateItem(Item item);
    }
}
