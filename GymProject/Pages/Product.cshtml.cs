using ClassLibrary.Classes.Item;
using ManagerLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymProject.Pages
{
    public class ProductModel : PageModel
    {
        public List<Item> Supplements { get; set; }
        public List<Item> Programs { get; set; }
        public readonly ManagerLibrary.ManagerClasses.ItemManager itemManager;
        public string Sort { get; set; }
        public string Type { get; set; }


        public ProductModel()
        {
            itemManager = new ManagerLibrary.ManagerClasses.ItemManager(new ItemRepository());
        }


        public void OnGet()
        {

            var supplements = itemManager.GetSupplements();

            var programs = itemManager.GetPrograms();

            Supplements = supplements;

            Programs = programs;
        }


        public void OnPost(string searchQuery, string sort)
        {
            if (!string.IsNullOrEmpty(searchQuery))
            {
                var searchResults = itemManager.SearchItems(searchQuery);
                Supplements = searchResults.Where(item => item.ItemType == ItemType.Supplement).ToList();
                Programs = searchResults.Where(item => item.ItemType == ItemType.Program).ToList();
            }

            if (!string.IsNullOrEmpty(sort))
            {
                List<Item> filteredSupplements = itemManager.GetSupplements();
                List<Item> filteredPrograms = itemManager.GetPrograms();
                if (sort == "lowToHigh")
                {
                    filteredSupplements = filteredSupplements.OrderBy(item => item.ItemPrice).ToList();
                    filteredPrograms = filteredPrograms.OrderBy(item => item.ItemPrice).ToList();
                }
                else if (sort == "highToLow")
                {
                    filteredSupplements = filteredSupplements.OrderByDescending(item => item.ItemPrice).ToList();
                    filteredPrograms = filteredPrograms.OrderByDescending(item => item.ItemPrice).ToList();
                }
                Supplements = filteredSupplements;
                Programs = filteredPrograms;
            }
        }
    }
}
