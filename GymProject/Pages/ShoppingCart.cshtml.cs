﻿using ClassLibrary.Classes.Item;
using Database.Repositories;
using GymProject.SessionHelper;
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
        public readonly ManagerLibrary.ManagerClasses.ItemManager itemManager = new ItemManager(new ItemRepository());
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
                var index = ExistingItem(cart, id);
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

        private int ExistingItem(List<Item> cart , int id)
        {
            for(int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ItemId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public void OnPost() {
            MyCart = SessionHelper.SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        }

        public void OnPostQuantity()
        {
            if (Quantity >= 1)
            {
                List<Item> cart = SessionHelper.SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

                Item itemToUpdate = cart.FirstOrDefault(item => item.ItemId == Id);

                if (itemToUpdate != null)
                {
                    itemToUpdate.ItemQuantity = Quantity + 1;

                    SessionHelper.SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
            }
        }


        public double TotalPrice(List<Item> selectedItems)
        {
            double totalPrice = 0;
            foreach (Item item in selectedItems)
            {
                totalPrice += item.ItemPrice;
            }
            return totalPrice;
        }
    }
}