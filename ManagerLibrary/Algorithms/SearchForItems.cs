using ClassLibrary.Classes.Item;
using ClassLibrary.Classes.User;
using InterfaceLibrary.IRepositories;
using ManagerLibrary.ManagerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.Algorithm
{
    public class SearchForItems
    {
        public static (List<Item> supplements, List<Item> programs) SearchItems(string searchQuery, List<Item> items)
        {
            var searchResults = items.Where(item => item.ItemName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            var supplements = searchResults.Where(item => item.ItemType == ItemType.Supplement).ToList();
            var programs = searchResults.Where(item => item.ItemType == ItemType.Program).ToList();
            return (supplements, programs);
        }
    }
}
