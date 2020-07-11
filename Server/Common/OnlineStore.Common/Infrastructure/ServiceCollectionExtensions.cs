using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineStore.Common.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase<TDbContext>(
            this IServiceCollection services,
            IConfiguration configuration)
            where TDbContext : DbContext
            => services
                .AddScoped<DbContext, TDbContext>()
                .AddDbContext<TDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}