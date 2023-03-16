using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes
{
    public class Item
    {
        private string itemName;
        private double itemPrice;
        private double itemQuantity;

        public Item(string itemName, double itemPrice)
        {
            GetItemName = itemName;
            GetItemPrice = itemPrice;
        }

        public Item(string itemName, double itemPrice, double itemQuantity)
        {
            GetItemName = itemName;
            GetItemPrice = itemPrice;
            GetItemQuantity = itemQuantity;
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
