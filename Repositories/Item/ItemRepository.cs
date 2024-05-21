using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Context;

namespace Repositories
{
    public class ItemRepository : IItemRepository
    {
        protected readonly ApplicationDbContext _dbContext;

        public ItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ItemDropDownModel>> GetDropdownItemsAsync(string searchString)
        {
             var dropDownList = await _dbContext.Items.Where(item => item.Name.Contains(searchString))
                .Select(item=>new ItemDropDownModel
                {
                    Id = item.Id,
                    Name = item.Name,
                })
                .ToListAsync();
            return dropDownList;
        }

        public async Task<Item> GetItemAsync(int id)
        {
            var item = await _dbContext.Items.FirstOrDefaultAsync(item => item.Id == id);
            return item;
        }

        public void Add(Item item)
        {
            _dbContext.Items.Add(item);
            _dbContext.SaveChanges();
        }

        public void Update(Item item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Delete(Item item) { 
            _dbContext.Items.Remove(item);
            _dbContext.SaveChanges();
        }
        public bool ItemExists(int id)
        {
            var item = _dbContext.Items.Find(id);
            return item != null;
        }
    }
}
