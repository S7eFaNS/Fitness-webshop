using ClassLibrary.Classes.Item;
using ClassLibrary.Classes.User;
using Database.Repositories;
using GymProject.SessionHelper;
using InterfaceLibrary.IAlgorithmService;
using ManagerLibrary.Algorithm;
using ManagerLibrary.ManagerClasses;
using ManagerLibrary.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;

namespace GymProject.Pages
{
    [Authorize(Roles = "Admin, Customer")]
    public class ShoppingCart : PageModel
    {
        public readonly ShoppingCartManager shoppingCartManager = new ShoppingCartManager(new ShoppingRepository());
        public readonly ManagerLibrary.ManagerClasses.ItemManager itemManager = new ItemManager(new ItemRepository());
        public readonly ShoppingCartAlgorithms shoppingCartAlgorithms = new ShoppingCartAlgorithms(new UserRepository());
        public readonly UserManager userManager = new UserManager(new UserRepository());
        public readonly ISuggestionItemService suggestionItems = new SuggestionItems(new UserRepository(), new ItemRepository(), new ShoppingRepository());
        public List<Item> MyCart = new List<Item>();
        public List<Item> Items { get; set; }
        [BindProperty]
        public int Quantity { get; set; }
        [BindProperty]
        public int Id { get; set; }
        public double Total { get; set; }
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            MyCart = SessionHelper.SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            Total = shoppingCartAlgorithms.CalculateTotalPrice(MyCart);

            string userEmail = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            
            User user = shoppingCartAlgorithms.GetUserFromAuthentication(userEmail);

            var suggestedItems = suggestionItems.GetProductSuggestions(user.Id);

            Items = suggestedItems;
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

        public IActionResult OnPostAddToCart(int itemId)
        {
            var product = itemManager.GetItemsById(itemId);
            var cart = SessionHelper.SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            if (cart == null)
            {
                cart = new List<Item>();
            }

            var existingItem = cart.FirstOrDefault(item => item.ItemId == itemId);

            if (existingItem != null)
            {
                existingItem.ItemQuantity++;
            }
            else
            {
                cart.Add(new Item
                {
                    ItemId = product.ItemId,
                    ItemName = product.ItemName,
                    ItemQuantity = 1,
                    ItemPrice = product.ItemPrice
                });
            }

            SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToPage("ShoppingCart");
        }



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
                Total = shoppingCartAlgorithms.CalculateTotalPrice(cart);
            }
            return RedirectToPage("ShoppingCart");
        }

        public IActionResult OnPostPlaceOrder(string address)
        {
            try
            {
                string userEmail = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                User user = shoppingCartAlgorithms.GetUserFromAuthentication(userEmail);
                MyCart = SessionHelper.SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                Total = shoppingCartAlgorithms.CalculateTotalPrice(MyCart);
                
                bool orderPlaced = shoppingCartManager.PlaceOrder(user, MyCart, address, Total);

                HttpContext.Session.Remove("cart");

                return RedirectToPage("Profile");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
        }
    }
}