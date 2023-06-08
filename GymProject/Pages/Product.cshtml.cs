using ClassLibrary.Classes.Item;
using ManagerLibrary.Algorithm;
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
                var searchResults = SearchForItems.SearchItems(searchQuery, itemManager.GetItems());
                Supplements = searchResults.supplements;
                Programs = searchResults.programs;
            }

            if (!string.IsNullOrEmpty(sort))
            {
                SortItems sortItems = new SortItems();
                List<Item> filteredSupplements = itemManager.GetSupplements();
                List<Item> filteredPrograms = itemManager.GetPrograms();
                if (sort == "lowToHigh")
                {
                    sortItems.SortByPriceAsc(filteredSupplements);
                    sortItems.SortByPriceAsc(filteredPrograms);
                }
                else if (sort == "highToLow")
                {
                    sortItems.SortByPriceDesc(filteredSupplements);
                    sortItems.SortByPriceDesc(filteredPrograms);
                }
                Supplements = filteredSupplements;
                Programs = filteredPrograms;
            }
        }
    }
}
