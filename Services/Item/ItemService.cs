using Common.ApiException;
using Models;
using Repositories;
using System.Reflection.Metadata.Ecma335;

namespace Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public Task<List<ItemDropDownModel>> GetDropdownItemsAsync(string searchString)
        {
          var resopnse = _itemRepository.GetDropdownItemsAsync(searchString);
            return(resopnse);
        }
        public void Save(Item item)
        {

            if (item.Id == 0)
            {
                _itemRepository.Add(item);
            }
            else
            {
                IsItemExists(item.Id);
                _itemRepository.Update(item);
            }
        }
        private void IsItemExists(int id)
        {
           bool isItemExists = _itemRepository.ItemExists(id);
            if (!isItemExists)
            {
                var errMessage = $"Item with the Id {id} does not exist.";
                throw new ApiException(ApiErrorCodes.BadRequest, errMessage);
            }
        }
        public void Delete(int id)
        {
            IsItemExists(id);
            _itemRepository.ItemExists(id);
        }
        public async  Task<Item> GetById(int id)
        {
            _itemRepository.ItemExists(id);
            var item = await _itemRepository.GetItemAsync(id);
           return item;
        }
    }
}
