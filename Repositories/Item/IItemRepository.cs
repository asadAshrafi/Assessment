using Models;

namespace Repositories
{
    public interface IItemRepository
    {
        void Add(Item item);
        Task<List<ItemDropDownModel>> GetDropdownItemsAsync(string searchString);
        Task<Item> GetItemAsync(int id);
        bool ItemExists(int id);
        void Update(Item item);
    }
}
