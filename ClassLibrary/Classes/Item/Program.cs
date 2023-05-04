﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.Item
{
    public class Program : Item
    {
        public string ProgramLink { get; set; }
        public Program() { }

        public Program(int id, string itemName, double itemPrice, string itemDescription, double itemQuantity, ItemType itemType, string programLink)
        {
            Id = id;
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemDescription = itemDescription;
            ItemQuantity = itemQuantity;
            ItemType = itemType;
            ProgramLink = programLink;
        }
    }
}
