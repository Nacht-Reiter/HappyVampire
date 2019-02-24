using HappyVampire.BusinessLogic.Interfaces;
using HappyVampire.BusinessLogic.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HappyVampire.BusinessLogic
{
    public static class BusinessLogicDI
    {
        // Register DI dependencies
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IHospitalService, HospitalService>();
            services.AddTransient<IDonationService, DonationService>();
            services.AddTransient<IDonorService, DonorService>();
            services.AddTransient<IAuthService, AuthService>();
        }

        public static void ConfigureMiddleware(this IApplicationBuilder app)
        {

        }
    }
}
