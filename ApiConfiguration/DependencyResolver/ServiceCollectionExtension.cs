using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyResolver
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBussinessLogicModules(this IServiceCollection services)
        {
            return services;
        }
    }
}
