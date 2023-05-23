﻿using ClassLibrary.Classes.Item;
using ClassLibrary.Classes.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.IRepositories
{
    public interface IShoppingRepository
    {
        bool PlaceOrder(User user, Item item, string address);
    }
}
