using ClassLibrary.Classes.Item;
using ClassLibrary.Classes.User;
using Database.Repositories;
using GymProject.SessionHelper;
using ManagerLibrary.Algorithm;
using ManagerLibrary.ManagerClasses;
using ManagerLibrary.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data;

namespace GymProject.Pages
{
    [Authorize(Roles = "Admin, Customer")]
    public class ShoppingCart : PageModel
    {
        public readonly ShoppingCartManager shoppingCartManager = new ShoppingCartManager(new ShoppingRepository());
        public readonly ManagerLibrary.ManagerClasses.ItemManager itemManager = new ItemManager(new ItemRepository());
        public readonly ShoppingCartAlgorithms shoppingCartAlgorithms = new ShoppingCartAlgorithms(new UserRepository());
        public List<Item> MyCart = new List<Item>();
        [BindProperty]
        public int Quantity { get; set; }
        [BindProperty]
        public int Id { get; set; }
        public double Total { get; set; }

        public void OnGet()
        {
            MyCart = SessionHelper.SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        }

        public IActionResult OnGetBuy(int id)
        {
            var product = itemManager.GetItemsById(id);
            var cart = SessionHelper.SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if(cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item()
                {
                    ItemId = product.ItemId,
                    ItemName = product.ItemName,
                    ItemQuantity = 1,
                    ItemPrice = product.ItemPrice
                });
                SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var index = ShoppingCartAlgorithms.ExistingItem(cart, id);
                if(index == -1)
                {
                    cart.Add(new Item
                    {
                        ItemId = product.ItemId,
                        ItemName = product.ItemName,
                        ItemQuantity =+ 1,
                        ItemPrice = product.ItemPrice
                    });
                }
                else
                {
                    var newQuantity = cart[index].ItemQuantity + 1;
                    cart[index].ItemQuantity = newQuantity;
                }
                SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("Product");
        }


        //move to back end


        //public void OnPost() {
        //    MyCart = SessionHelper.SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        //}
        
        public IActionResult OnPostQuantity(string action)
        {
            if (Quantity >= 1)
            {
                List<Item> cart = SessionHelper.SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

                Item itemToUpdate = cart.FirstOrDefault(item => item.ItemId == Id);

                if (itemToUpdate != null)
                {
                    if (action == "increase")
                    {
                        itemToUpdate.ItemQuantity++;
                    }
                    else if (action == "decrease")
                    {
                        if (itemToUpdate.ItemQuantity > 1)
                        {
                            itemToUpdate.ItemQuantity--;
                        }
                        else
                        {
                            cart.Remove(itemToUpdate);
                        }
                    }

                    SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
            }
            return RedirectToPage("ShoppingCart");
        }

        public IActionResult OnPostPlaceOrder(string address)
        {
            User user = shoppingCartAlgorithms.GetUserFromAuthentication(Id);
            List <Item> cart = SessionHelper.SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            double totalPrice = shoppingCartAlgorithms.CalculateTotalPrice(cart);
            
            bool orderPlaced = shoppingCartManager.PlaceOrder(user, cart, address, totalPrice);
            
            return RedirectToPage("Profile");
        }

        //public double TotalPrice(List<Item> selectedItems)
        //{
        //    double totalPrice = 0;
        //    foreach (Item item in selectedItems)
        //    {
        //        totalPrice += item.ItemPrice;
        //    }
        //    return totalPrice;
        //}
    }
}