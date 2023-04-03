using Database.DataBase;
using ClassLibrary.Classes.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLibrary.Interfaces;
using ManagerLibrary.Repositories;

namespace ManagerLibrary.ManagerClasses
{
    public class ItemManager /*: IItemManager*/
    {
        //private ItemCatalogue itemCatalogue;
        //private ItemRepository itemRepository;

        //public ItemManager(ItemCatalogue itemCatalogue, ItemRepository itemRepository)
        //{
        //    this.itemCatalogue = itemCatalogue;
        //    this.itemRepository = itemRepository;
        //}

        //public List<Item> GetAllItems()
        //{
        //    List<Item> itemList = itemCatalogue.GetItemList();

        //    if (itemList.isEmpty())
        //    {
        //        itemList = itemRepository.GetAllItems();
        //        itemCatalogue = new ItemCatalogue(itemList);
        //    }

        //    return itemList;
        //}

        //public void AddItem(Item item)
        //{
        //    itemRepository.AddItem(item);
        //    itemCatalogue.AddItem(item);
        //}

        //public void RemoveItem(int itemId)
        //{
        //    itemRepository.RemoveItem(itemId);
        //    itemCatalogue.RemoveItem(itemId);
        //}

        //public void UpdateItem(Item item)
        //{
        //    itemRepository.UpdateItem(item);
        //    itemCatalogue.UpdateItem(item);
        //}
    }
}

