using ClassLibrary.Classes.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.Interfaces
{
    public interface IItemManager
    {
        public List<Item> GetAllItems();

        public void AddItem(Item item);

        public void RemoveItem(int itemId);

        public void UpdateItem(Item item);
    }
}
