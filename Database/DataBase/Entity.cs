using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DataBase
{
    public class Entity
    {
        [PrimaryKey]
        public int Id { get; set; }
        protected void SetId(int id) { this.Id = id; }
    }
}
