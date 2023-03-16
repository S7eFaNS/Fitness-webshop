using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes
{
    public class AdministrationItem
    {
        private List<Item> items;

        public AdministrationItem() { }

        public List<Item> Items { get { return items;} }

        public void AddItem(Item item) 
        { 
            items.Add(item);
        }

        public void RemoveItem(Item item) 
        { 
            items.Remove(item);
        }
    }
}
