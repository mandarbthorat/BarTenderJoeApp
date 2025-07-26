using BarTenderJoe.Application.Interfaces;
using BarTenderJoe.Domain.Services;
using BarTenderJoe.Domain.Strategies;
using BarTenderJoe.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTenderJoe.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, InMemoryProductRepository>();
            services.AddScoped<IDrinkMixerStrategy, MilkDrinkMixer>();
            services.AddScoped<IDrinkMixerStrategy, OrangeDrinkMixer>();

            return services;
        }
    }
}
