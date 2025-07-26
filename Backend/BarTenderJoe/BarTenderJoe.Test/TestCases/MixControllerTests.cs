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
    public class MixControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public MixControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task MixDrink_ValidProduct_ReturnsDrinkMessage()
        {
            var response = await _client.PostAsJsonAsync("/api/mix", new { ProductId = 1 });
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await response.Content.ReadFromJsonAsync<dynamic>();
            string drink = result?.drink;
            drink.Should().Be("Milkshake is ready!");
        }

        [Fact]
        public async Task MixDrink_InvalidProduct_ReturnsBadRequest()
        {
            var response = await _client.PostAsJsonAsync("/api/mix", new { ProductId = 99 });
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
