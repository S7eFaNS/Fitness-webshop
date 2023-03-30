using Database.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.Item
{
    public class ItemViewModel
    {
        [Required(ErrorMessage = "Id field is required for product")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field is required for product")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Price field is required for product"), Range(0, 200)]
        public double ItemPrice { get; set; }

        [Required(ErrorMessage = "Description field is required for product")]
        public string ItemDescription { get; set; }

        [Required(ErrorMessage = "Quantity field is required for product")]
        public int ItemQuantity { get; set; }

        public override string ToString()
        {
            string s = $"{ItemName} - price: {ItemPrice}";
            for (int i = 0; i < (40 - $"{ItemName} - price: {ItemPrice}".Length); i++)
            {
                s += " ";
            }
            return s;
        }
    }
}
