using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace OutlayManager.DataAccess
{
    public static class DataAccessDI
    {

        // Register DI dependencies
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

        }

        public static void ConfigureMiddleware(this IApplicationBuilder app)
        {

        }
    }
}
