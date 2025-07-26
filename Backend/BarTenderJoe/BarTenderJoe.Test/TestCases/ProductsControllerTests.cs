using BarTenderJoe.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BarTenderJoe.Test.TestCases
{
    public class ProductsControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ProductsControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetProduct_ValidId_ReturnsProduct()
        {
            var response = await _client.GetAsync("/api/products/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var product = await response.Content.ReadFromJsonAsync<Product>();
            product!.Name.Should().Be("Milk");
        }

        [Fact]
        public async Task GetProduct_InvalidId_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/products/99");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
