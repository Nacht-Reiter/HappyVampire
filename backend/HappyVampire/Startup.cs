using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyVampire.Authentication;
using HappyVampire.BusinessLogic;
using HappyVampire.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OutlayManager.DataAccess;

namespace HappyVampire
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );
            services.AddFirebaseAuthentication(Configuration.GetValue<string>("Firebase:ProjectId"));

            DataAccessDI.ConfigureServices(services, Configuration);
            BusinessLogicDI.ConfigureServices(services, Configuration);
            CommonDI.ConfigureServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("AllowAll");

            DataAccessDI.ConfigureMiddleware(app);
            BusinessLogicDI.ConfigureMiddleware(app);
            CommonDI.ConfigureMiddleware(app);
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
