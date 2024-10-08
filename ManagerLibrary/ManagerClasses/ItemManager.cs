﻿using Database.DataBase;
using ClassLibrary.Classes.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerLibrary.Repositories;
using ClassLibrary.Classes.User;
using InterfaceLibrary.IRepositories;

namespace ManagerLibrary.ManagerClasses
{
    public class ItemManager
    {
        private readonly IItemRepository itemRepository;

        public ItemManager(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }


        public List<Item> GetItems()
        {
            return itemRepository.GetItems();
        }

        public List<Item> GetSupplements()
        {
            return itemRepository.GetSupplements();
        }

        public List<Item> GetPrograms()
        {
            return itemRepository.GetPrograms();
        }

        public Item GetItemsById(int id)
        {
            return itemRepository.GetItemById(id);
        }

        public List<Item> SearchItems(string searchQuery)
        {
            return itemRepository.SearchItems(searchQuery);
        }

        public bool CreateItem(Item item)
        {
            if (item is Programs)
            {
                var program = item as Programs;
                return itemRepository.CreateItem(program);
            }
            else if (item is Supplement)
            {
                var supplement = item as Supplement;
                return itemRepository.CreateItem(supplement);
            }
            else
            {
                throw new ArgumentException("Invalid item type");
            }
        }

        public bool UpdateItem(Item item)
        {
            if (item is Programs)
            {
                var program = item as Programs;
                return itemRepository.UpdateItem(program);
            }
            else if (item is Supplement)
            {
                var supplement = item as Supplement;
                return itemRepository.UpdateItem(supplement);
            }
            else
            {
                throw new ArgumentException("Invalid item type");
            }
        }

        public bool DeleteItem(int id)
        {
            Item item = itemRepository.GetItemById(id);
            if (item == null)
            {
                throw new ArgumentException("Item not found");
            }
            else if (item.ItemType == ItemType.Program)
            {
                return itemRepository.DeleteItem(item);
            }
            else if (item.ItemType == ItemType.Supplement)
            {
                return itemRepository.DeleteItem(item);
            }
            else
            {
                throw new ArgumentException("Invalid item type");
            }
        }
    }
}

