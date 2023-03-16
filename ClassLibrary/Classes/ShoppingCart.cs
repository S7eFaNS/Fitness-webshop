using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes
{
    public class ShoppingCart
    {
        private List<Item> selectedItems { get; set; }

        public ShoppingCart() 
        {
            selectedItems = new List<Item>();
        }

        public void AddItem(Item item)
        {
            selectedItems.Add(item);
        }

        public void RemoveItem(Item item)
        {
            selectedItems.Remove(item);
        }

        public void Clear()
        {
            selectedItems.Clear();
        }

        public double GetTotalPrice()
        {
            double totalPrice = 0.0;

            foreach (var item in selectedItems)
            {
                totalPrice += item.GetItemPrice;
            }

            return totalPrice;
        }

        public void RegisterSale ()
        {

        }
    }
}
