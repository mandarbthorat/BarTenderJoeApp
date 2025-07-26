using BarTenderJoe.Application.Commands;
using BarTenderJoe.Application.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTenderJoe.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<GetProductHandler>();
            services.AddScoped<MixDrinkHandler>();

            return services;
        }
    }
}
