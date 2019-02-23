using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using HappyVampire.DataAccess.Repository;

namespace OutlayManager.DataAccess
{
    public static class DataAccessDI
    {

        // Register DI dependencies
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            string connectionStr = configuration.GetConnectionString("HappyVampireDatabase");
            services.AddDbContext<DataContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(connectionStr);
            });
            services.AddScoped(typeof(DbContext), typeof(DataContext));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureMiddleware(this IApplicationBuilder app)
        {

        }
    }
}
