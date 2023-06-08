using ClassLibrary.Classes.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.Algorithm
{
    public class SortItems
    {
        public SortItems() { }
        
        public IComparer<T> Reversed<T>(IComparer<T> comparer)
        {
            return Comparer<T>.Create((x, y) => comparer.Compare(y, x));
        }

        public void SortByPriceAsc(List<Item> items)
        {
            items.Sort(new ItemPriceComparer());
        }

        public void SortByPriceDesc(List<Item> items)
        {
            items.Sort(Reversed(new ItemPriceComparer()));
        }

        public void SortByQuantityAsc(List<Item> items)
        {
            items.Sort(new ItemQuantityComparer());
        }

        public void SortByQuantityDesc(List<Item> items)
        {
            items.Sort(Reversed(new ItemQuantityComparer()));
        }

        public List<Item> SortByItemTypeSupplement(List<Item> items)
        {
            return items = items.Where(item => item.ItemType == ItemType.Supplement).ToList();
        }

        public List<Item> SortByItemTypeProgram(List<Item> items)
        {
            return items = items.Where(item => item.ItemType == ItemType.Program).ToList();
        }
    }
}
