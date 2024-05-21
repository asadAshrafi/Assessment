using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Context;

namespace Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ApplicationDbContext>();
            return services;
        }
    }
}
