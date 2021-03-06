﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HappyVampire.Common
{
    public static class CommonDI
    {
        // Register DI dependencies
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMapper>(sp => AutoMapper.GetDefaultMapper());
        }

        public static void ConfigureMiddleware(this IApplicationBuilder app)
        {

        }
    }
}
