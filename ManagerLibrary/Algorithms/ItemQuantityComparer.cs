using ClassLibrary.Classes.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.Algorithm
{
    public class ItemQuantityComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return x.ItemQuantity.CompareTo(y.ItemQuantity);
        }
    }
}
