using ClassLibrary.Classes.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.IAlgorithmService
{
    public interface ISuggestionItemService
    {
        List<Item> GetProductSuggestions(int userId);
    }
}
