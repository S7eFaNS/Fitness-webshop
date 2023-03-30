using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Database.DataBase;

namespace ClassLibrary.Classes.Item
{
    public abstract class Item : Entity
    {
        [ColumnName("name")]
        protected string ItemName { get; set; }

        [ColumnName("price")]
        protected double ItemPrice { get; set; }

        [ColumnName("description")]
        protected string ItemDescription { get; set; }

        [ColumnName("quantity")]
        protected double ItemQuantity { get; set; }

        public Item(int id, string itemName, double itemPrice, string itemDescription, double itemQuantity)
        {
            SetId(id);
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemDescription = itemDescription;
            ItemQuantity = itemQuantity;
        }

        public Item()
        {

        }
    }
}
