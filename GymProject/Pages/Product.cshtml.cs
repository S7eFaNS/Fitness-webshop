using ClassLibrary.Classes.Item;
using ManagerLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymProject.Pages
{
    public class ProductModel : PageModel
    {
        public List<Item> Items { get; set; }
        public readonly ManagerLibrary.ManagerClasses.ItemManager itemManager;
        
        public ProductModel()
        {
            itemManager = new ManagerLibrary.ManagerClasses.ItemManager(new ItemRepository());
        }


        public void OnGet()
        {
            Items = itemManager.GetItems();
        }

        public void OnPost(string searchQuery)
        {
            if (!string.IsNullOrEmpty(searchQuery))
            {
                Items = itemManager.SearchItems(searchQuery);
            }
        }

        //public void OnPostSortByPriceLowToHigh()
        //{
        //    if (Items != null && Items.Count > 0)
        //    {
        //        Items = Items.OrderBy(x => x.ItemPrice).ToList();
        //    }
        //}

        //public void OnPostSortByPriceHighToLow()
        //{
        //    if (Items != null && Items.Count > 0)
        //    {
        //        Items = Items.OrderByDescending(x => x.ItemPrice).ToList();
        //    }
        //}
    }
}
