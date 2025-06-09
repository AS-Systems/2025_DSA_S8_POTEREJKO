using LibraryManager.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Model
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLibraryDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<HomelibraryContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            return services;
        }
    }
}
