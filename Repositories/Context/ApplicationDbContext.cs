using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 1, Name = "Microwave oven", Price = 10, Description = "Lorem Ipsum is simply dummy text of the printing and typesetting" },
                new Item { Id = 2, Name = "Sunglasses", Price = 34, Description = "Contrary to popular belief, Lorem Ipsum is not simply random text." },
                new Item { Id = 3, Name = "Speaker", Price = 78, Description = "There are many variations of passages of Lorem Ipsum available" },
                new Item { Id = 4, Name = "Watch", Price = 188, Description = "The standard chunk of Lorem Ipsum used since the 1500s" },
                new Item { Id = 5, Name = "Laptop", Price = 1340, Description = "in voluptate velit esse cillum dolore eu fugiat nulla pariatur" }
        );
                }
    }
}
