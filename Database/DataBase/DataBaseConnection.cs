using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DataBase
{
    public class DataBaseConnection
    {
        public string ConnectionString { get; set; }

        public DataBaseConnection()
        {
            ConnectionString = "Server=mssqlstud.fhict.local;Database=dbi500182;User Id=dbi500182;Password=123;";
        }
        //it can be done automatically

    }
}
