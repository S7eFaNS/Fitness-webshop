using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.Item
{
    public class Supplement : Item
    {
        public string Name { get => base.ItemName; set => base.ItemName = value; }
        public double Price { get => base.ItemPrice; set => base.ItemPrice = value; }
        public string Description { get => base.ItemDescription; set => base.ItemDescription = value; }
        public double Quantity { get => base.ItemQuantity; set => base.ItemQuantity = value; }
        public bool IsSupplement { get; internal set; }
    }
}
