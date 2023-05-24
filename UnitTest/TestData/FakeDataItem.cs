using ClassLibrary.Classes.Item;
using ClassLibrary.Classes.User;
using InterfaceLibrary.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.TestData
{
    public class FakeDataItem : IItemRepository
    {
        private readonly List<Item> items;

        public FakeDataItem()
        {
            items = new List<Item>()
            {
                new Item(1, "testTren1", 10, "testDataTren1", 10, ItemType.Supplement),
                new Item(2, "testTren2", 20, "testDataTren2", 20, ItemType.Supplement),
                new Item(3, "testTren3", 30, "testDataTren3", 30, ItemType.Supplement),
                new Item(4, "testTren4", 40, "testDataTren4", 40, ItemType.Supplement),
            };
        }
        public List<Item> GetItems()
        {
            return items;
        }

        public Item? GetItemById(int id)
        {
            return items.Find(i => i.ItemId== id);
        }


        public bool CreateItem(Item item)
        {
            items.Add(item);
            return items.Count > 4;
        }

        public bool DeleteItem(Item item)
        {
            int index = items.FindIndex(i => i.ItemId == item.ItemId);
            if(index >= 0) 
            {
                items.RemoveAt(index);
            }
            return true;
        }

        public bool UpdateItem(Item item)
        {
            int index = items.FindIndex(i => i.ItemId == item.ItemId);
            if(index >= 0)
            {
                items[index] = item;
            }
            return true;
        }


        public List<Item> SearchItems(string searchQuery)
        {
            List<Item> foundItems = new();
            foreach (var item in items)
            {
                if (item.ItemName.Contains(searchQuery) ||
                    item.ItemId.ToString().Contains(searchQuery) ||
                    item.ItemPrice.ToString().Contains(searchQuery))
                {
                    foundItems.Add(item);
                }
            }
            return foundItems;
        }

        public List<Item> GetPrograms()
        {
            throw new NotImplementedException();
        }

        public List<Item> GetSupplements()
        {
            throw new NotImplementedException();
        }
    }
}
