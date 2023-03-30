using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DataBase
{
    public class ColumnName : Attribute
    {
        public string Name { get; private set; }
        public ColumnName(string name) { this.Name = name; }
    }

    internal class PrimaryKey : ColumnName
    {
        public bool IsPrimaryKey { get; private set; }
        public PrimaryKey(string name = "id") : base(name) { this.IsPrimaryKey = true; }
    }
}
