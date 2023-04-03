using ClassLibrary.Classes.Item;
using Database.DataBase;
using InterfaceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.Repositories
{
    public class ItemRepository : IItemManager
    {
        public List<Item> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}