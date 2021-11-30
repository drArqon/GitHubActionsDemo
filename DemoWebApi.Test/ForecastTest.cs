using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace DemoWebApi.Test
{
    public class ForecastTest
    {

        protected readonly HttpClient TestClient;

        public ForecastTest()
        {
            var appFactory = new WebApplicationFactory<Program>();
            //_serviceProvider = appFactory.Services;
            TestClient = appFactory.CreateClient();
        }


        [Fact]
        public async Task GetAll_WithoutAnyPosts_ReturnsEmptyResponse()
        {

            // Act
            var response = await TestClient.GetAsync("/forecast/");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var forecast = (await response.Content.ReadAsAsync<WeatherForecast[]>());

            forecast.Should().NotBeEmpty();
        }
    }
}
