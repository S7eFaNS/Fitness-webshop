using ClassLibrary.Classes.Item;
using Database.Repositories;
using ManagerLibrary.ManagerClasses;
using ManagerLibrary.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace GymProject.Pages
{
    [Authorize(Roles = "Admin, Customer")]
    public class ShoppingCart : PageModel
    {
        public readonly ShoppingCartManager shoppingCartManager = new ShoppingCartManager(new ShoppingRepository());
        public List<Item> cart { get; set; }
        public double Total { get; set; }


        public void OnGet()
        {
            
        }

        public void OnPost() { 
            
        }

        public double TotalPrice(List<Item> selectedItems)
        {
            double totalPrice = 0;
            foreach (Item item in selectedItems)
            {
                totalPrice += item.ItemPrice * item.ItemQuantity;
            }
            return totalPrice;
        }
    }
}