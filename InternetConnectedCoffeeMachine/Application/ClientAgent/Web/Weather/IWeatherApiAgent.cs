
namespace InternetConnectedCoffeeMachine.Application.ClientAgent.Web.Weather
{
    public interface IWeatherApiAgent
    {
        Task<WeatherResponse> GetCurrentTemperatureAsync();
    }
}
