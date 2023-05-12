using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.Delegates
{
    public class Delegate
    {
        //Users
        public delegate void AdminCreatedEventHandler(object sender, EventArgs e);
        public delegate void UserEditedEventHandler(object sender, EventArgs e);
        public delegate void UserDeletedEventHandler(object sender, EventArgs e);
    }
}
