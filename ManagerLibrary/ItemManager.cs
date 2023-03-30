using Database.DataBase;
using ClassLibrary.Classes.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    //public class ItemManager
    //{
    //    private ItemProgramRepository programRepository = new();
    //    private ItemSupplementRepository supplementRepository = new();

    //    public void CreateProgram(ItemViewModel viewModel)
    //    {
    //        Program record = Helpers.MapToEntity<ItemViewModel, Program>(viewModel);
    //        programRepository.Create(record);
    //    }

    //    public void CreateSupplement(ItemViewModel viewModel)
    //    {
    //        Supplement record = Helpers.MapToEntity<ItemViewModel, Supplement>(viewModel);
    //        supplementRepository.Create(record);
    //    }

    //    public ItemViewModel FindById(int id)
    //    {
    //        Item? record = programRepository.Read(id) ?? supplementRepository.Read(id);
    //        if (record == null) throw new Exception($"Animal with id {id} is not found");
    //        return Helpers.MapToModel<Item, ItemViewModel>(record);
    //    }

    //    public IEnumerable<ItemViewModel> FindAll()
    //    {
    //        return repository.ReadAll().Select(record => Helpers.MapToModel<Item, ItemViewModel>(record));
    //    }

    //    public ItemViewModel FindByName(string name)
    //    {
    //        Item? record = repository.Read(name);
    //        if (record == null) throw new Exception($"Animal with name {name} is not found");
    //        return Helpers.MapToModel<Item, ItemViewModel>(record);
    //    }

    //    public IEnumerable<ItemViewModel> FindAllByName(string name)
    //    {
    //        return repository.ReadAll(name).Select(record => Helpers.MapToModel<Item, ItemViewModel>(record));
    //    }

    //    public void FindAndUpdate(ItemViewModel viewModel, double price)
    //    {
    //        if (price == viewModel.ItemPrice) return;
    //        viewModel.ItemPrice = price;
    //        Item entity = Helpers.MapToEntity<ItemViewModel, Item>(viewModel);
    //        repository.Update(entity);
    //    }

    //    public void FindAndUpdate(ItemViewModel viewModel, string name)
    //    {
    //        if (name == viewModel.ItemName) return;
    //        viewModel.ItemName = name;
    //        Item entity = Helpers.MapToEntity<ItemViewModel, Item>(viewModel);
    //        repository.Update(entity);
    //    }

    //    public void FindAndUpdate(ItemViewModel viewModel, double price)
    //    {
    //        if (price == viewModel.ItemPrice) return;
    //        viewModel.ItemPrice = price;
    //        Item entity = Helpers.MapToEntity<ItemViewModel, Item>(viewModel);
    //        repository.Update(entity);
    //    }

    //    public void FindByIdAndDelete(int id)
    //    {
    //        repository.Delete(id);
    //    }
    //}
}
