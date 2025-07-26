using BarTenderJoe.Application.Interfaces;
using BarTenderJoe.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;

namespace BarTenderJoe.Test
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseContentRoot(AppContext.BaseDirectory);
            builder.ConfigureServices(services =>
            {
                // Remove existing IProductRepository registration
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(IProductRepository));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add test repository
                services.AddScoped<IProductRepository, InMemoryProductRepository>();
            });
        }
    }
}