using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ClassLibrary.Classes.Item
{
    public class Item
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public double ItemPrice { get; set; }

        public string ItemDescription { get; set; }

        public int ItemQuantity { get; set; }

        public ItemType ItemType { get; set; }

        public Item(int id, string itemName, double itemPrice, string itemDescription, int itemQuantity, ItemType itemType)
        {
            ItemId = id;
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemDescription = itemDescription;
            ItemQuantity = itemQuantity;
            ItemType = itemType;
        }

        public Item()
        {

        }
    }
}
