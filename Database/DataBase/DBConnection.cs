using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.DataBase
{
    public class DBConnection
    {
        const string connectionString = "server=mssqlstud.fhict.local;database=dbi500182;User Id=dbi500182;password=123"; 

        public DBConnection(string connectionString)
        {

        }

        public void SaveCustomerDetails(User user)
        {

        }

        public void DeleteCustomerDetails(User user)
        {

        }

        public void SaveItemDetails(Item item)
        {

        }

        public void DeleteItemDetails(Item item)
        {

        }

        public void LoadItems()
        {

        }

        public void RegisterSale (User user, Item item)
        {

        }
    }
}
