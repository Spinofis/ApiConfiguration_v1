﻿using App.Services.Test1;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Extensions
{
    public static class ServicesExtension
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<ITest1Serivice, Test1Service>();
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc
                ("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "App Api",
                    Version = "v1"
                });
            });
        }
    }
}
