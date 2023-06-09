using ClassLibrary.Classes.Item;
using ClassLibrary.Classes.User;
using Database.Repositories;
using InterfaceLibrary.IAlgorithmService;
using InterfaceLibrary.IRepositories;
using ManagerLibrary.Algorithm;
using ManagerLibrary.Algorithms;
using ManagerLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace GymProject.Pages
{
    public class ProductModel : PageModel
    {
        public List<Item> Supplements { get; set; }
        public List<Item> Programs { get; set; }
        public readonly ManagerLibrary.ManagerClasses.ItemManager itemManager;
        public string Sort { get; set; }
        public string Type { get; set; }
        public List<Item> MostBoughtItems { get; set; }
        public ISuggestionItemService suggestionItemService = new SuggestionItemsService(new UserRepository(), new ItemRepository(), new ShoppingRepository());
        public readonly ShoppingCartAlgorithms shoppingCartAlgorithms = new ShoppingCartAlgorithms(new UserRepository());


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

            string userEmail = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            if (User.Identity.IsAuthenticated)
            {
                User user = shoppingCartAlgorithms.GetUserFromAuthentication(userEmail);

                List<Item> mostBoughtItems = suggestionItemService.GetProductSuggestions(user.Id);
                MostBoughtItems = mostBoughtItems;
            }
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
