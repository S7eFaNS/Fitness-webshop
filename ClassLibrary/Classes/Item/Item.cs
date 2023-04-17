using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ClassLibrary.Classes.Item
{
    public abstract class Item
    {
        public int Id { get; set; }

        protected string ItemName { get; set; }

        protected double ItemPrice { get; set; }

        protected string ItemDescription { get; set; }

        protected double ItemQuantity { get; set; }

        protected ItemType ItemType { get; set; }

        public Item(int id, string itemName, double itemPrice, string itemDescription, double itemQuantity, ItemType itemType)
        {
            Id = id;
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
