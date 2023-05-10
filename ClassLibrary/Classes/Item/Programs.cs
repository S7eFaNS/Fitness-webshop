using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.Item
{
    public class Programs : Item
    {
        public string ProgramLink { get; set; }
        public Programs() { }

        public Programs(int id, string itemName, double itemPrice, string itemDescription, int itemQuantity, ItemType itemType, string programLink)
        {
            ItemId = id;
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemDescription = itemDescription;
            ItemQuantity = itemQuantity;
            ItemType = itemType;
            ProgramLink = programLink;
        }
    }
}
