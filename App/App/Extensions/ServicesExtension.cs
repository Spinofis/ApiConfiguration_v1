using App.AzureStorageManager;
using App.Services.Files;
using App.Services.Test1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
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
            services.AddScoped<IFileService, FileService>();
        }

        public static void AddAzureStorageManager(this IServiceCollection services, IConfiguration config)
        {
            string azureKey = config.GetSection("AzureStorage").GetValue<string>("ConnectionString");
            string rootDir = config.GetSection("AzureStorage").GetValue<string>("ShareReferenceName");

            services.AddScoped<IAzureFileManager, AzureStorageManager.AzureFileManager>
                (
                    x => new AzureStorageManager.AzureFileManager(azureKey, rootDir)
                );
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }
    }
}
