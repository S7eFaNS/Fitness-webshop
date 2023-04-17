﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.Item
{
    public class Supplement : Item
    {
        public Supplement() { }

        public Supplement(int id, string itemName, double itemPrice, string itemDescription, double itemQuantity, ItemType itemType)
        {
            Id = id;
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemDescription = itemDescription;
            ItemQuantity = itemQuantity;
            ItemType = itemType;
        }
    }
}
