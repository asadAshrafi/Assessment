using Models;

namespace Services
{
    public interface IItemService
    {
        void Delete(int id);
        Task<Item> GetById(int id);
        Task<List<ItemDropDownModel>> GetDropdownItemsAsync(string searchString);
        void Save(Item item);
    }
}
