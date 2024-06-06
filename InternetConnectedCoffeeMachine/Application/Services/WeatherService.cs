
using InternetConnectedCoffeeMachine.Application.ClientAgent.Web.Weather;

namespace InternetConnectedCoffeeMachine.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherApiAgent _weatherApiAgent;

        public WeatherService(IWeatherApiAgent weatherApiAgent)
        {
            _weatherApiAgent = weatherApiAgent;
        }

        public async Task<float> GetCurrentTemperature()
        {
            var response = await _weatherApiAgent.GetCurrentTemperatureAsync();

            if (response == null || response.main == null)
            { return default; }

            return response.main.temp;
        }
    }
}
