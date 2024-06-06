using FluentAssertions;
using InternetConnectedCoffeeMachine.Application.Models;
using InternetConnectedCoffeeMachine.Application.Services;
using InternetConnectedCoffeeMachine.Integration.Extensions;
using InternetConnectedCoffeeMachine.Integration.Fakes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace InternetConnectedCoffeeMachine.Integration
{
    public class CoffeeControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        private readonly DateTime CurrentDateTime = DateTime.Parse("2/06/2024 6:50:22 PM");
        private const string CurrentDateTimeIsoFormat = "2024-06-02T18:50:22+10:00";
        private readonly DateTime AprilFirstDateTime = DateTime.Parse("1/04/2024 6:50:22 PM");
        private readonly Mock<IDateTimeProvider> DateTimeProviderFake = new Mock<IDateTimeProvider>();
        private readonly Mock<IWeatherService> WeatherServiceFake = new Mock<IWeatherService>();
        public CoffeeControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory
                  .WithWebHostBuilder(builder =>
                  {
                      builder.ConfigureServices(services =>
                      {
                          services.Replace(ServiceDescriptor.Singleton(typeof(IDateTimeProvider), DateTimeProviderFake.ConfigureGetCurrentDateTime(CurrentDateTime).Object));
                      });
                  });

            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task WhenCalling_Get_Brew_Coffee_Should_Returns_OKResponse_And_ResultData()
        {
            // Arrange
            var url = $"{_client.BaseAddress}brew-coffee";

            // Act
            var responseMessage = await _client.GetAsync(url);

            // Assert
            responseMessage.EnsureSuccessStatusCode();
            var coffee = await responseMessage.DeserializeContentAsync<CoffeeModel>();
            coffee.Should().NotBeNull();
            coffee.Message.Should()
                .Be(Constants.Message.CoffeeReadyMessage);
            coffee.Prepared.Should().BeEquivalentTo(CurrentDateTimeIsoFormat);
        }

        [Fact]
        public async Task WhenCalling_Get_Brew_Coffee_More_Than_FiveTimes_Should_Returns_503Response()
        {
            // Arrange
            var url = $"{_client.BaseAddress}brew-coffee";
            var serviceWorkTimes = 5;
            var count = 0;

            // Act
            do
            {
                count++;
                await _client.GetAsync(url);
            } while (count / serviceWorkTimes == 0);

            var responseMessage = await _client.GetAsync(url);

            // Assert
            responseMessage.Should().HaveStatusCode(System.Net.HttpStatusCode.ServiceUnavailable);
        }

        [Fact]
        public async Task WhenCalling_Get_Brew_Coffee_On_April_First_Should_Returns_418Response()
        {
            // Arrange
            var currentFactory = _factory
                  .WithWebHostBuilder(builder =>
                  {
                      builder.ConfigureServices(services =>
                      {
                          services.Replace(ServiceDescriptor.Singleton(typeof(IDateTimeProvider), DateTimeProviderFake.ConfigureGetCurrentDateTime(AprilFirstDateTime).Object));
                      });
                  });
            var client = currentFactory.CreateClient();

            var url = $"{client.BaseAddress}brew-coffee";

            // Act
            var responseMessage = await client.GetAsync(url);

            // Assert
            responseMessage.Should().HaveStatusCode((System.Net.HttpStatusCode)StatusCodes.Status418ImATeapot);

        }

        [Fact]
        public async Task WhenCalling_Get_Brew_Coffee_In_Hot_Day_Should_Returns_IcedCoffee()
        {
            // Arrange
            var currentFactory = _factory
                  .WithWebHostBuilder(builder =>
                  {
                      builder.ConfigureServices(services =>
                      {
                          services.Replace(ServiceDescriptor.Scoped(typeof(IWeatherService), w => WeatherServiceFake.ConfigureGetCurrentTemperature(35).Object));
                      });
                  });
            var client = currentFactory.CreateClient();

            var url = $"{client.BaseAddress}brew-coffee";

            // Act
            var responseMessage = await client.GetAsync(url);

            // Assert
            responseMessage.EnsureSuccessStatusCode();
            var coffee = await responseMessage.DeserializeContentAsync<CoffeeModel>();
            coffee.Should().NotBeNull();
            coffee.Message.Should()
                .Be(Constants.Weather.IcedCoffeeReadyMessage);
            coffee.Prepared.Should().BeEquivalentTo(CurrentDateTimeIsoFormat);

        }
    }
}