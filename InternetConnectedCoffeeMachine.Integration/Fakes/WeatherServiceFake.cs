using InternetConnectedCoffeeMachine.Application.Services;
using Moq;

namespace InternetConnectedCoffeeMachine.Integration.Fakes
{
    internal static class WeatherServiceFake
    {
        internal static Mock<IWeatherService> ConfigureGetCurrentTemperature(
            this Mock<IWeatherService> instance, float response)
        {
            instance.Setup(x => x.GetCurrentTemperature())
                .ReturnsAsync(() => response);

            return instance;
        }
    }
}
