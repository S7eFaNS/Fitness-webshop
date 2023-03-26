using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes
{
    public class Item
    {
        private int itemId;
        private string itemName;
        private double itemPrice;
        private double itemQuantity;

        public Item(string itemName, double itemPrice)
        {
            GetItemName = itemName;
            GetItemPrice = itemPrice;
        }

        public Item(int itemId, string itemName, double itemPrice, double itemQuantity)
        {
            GetId = itemId;
            GetItemName = itemName;
            GetItemPrice = itemPrice;
            GetItemQuantity = itemQuantity;
        }

        public int GetId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public string GetItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        public double GetItemPrice
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }

        public double GetItemQuantity
        {
            get { return itemQuantity; }
            set { itemQuantity = value; }
        }
    }
}
