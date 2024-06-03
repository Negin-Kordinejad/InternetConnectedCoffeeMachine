
using InternetConnectedCoffeeMachine.Application.ClientAgent.Web.Weather;

namespace InternetConnectedCoffeeMachine.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherApiAgent _weatherApiAgent;
        private float defult;

        public WeatherService(IWeatherApiAgent weatherApiAgent)
        {
            _weatherApiAgent = weatherApiAgent;
        }

        public async Task<float> GetCurrentTemperature()
        {
            var response = await _weatherApiAgent.GetCurrentTemperatureAsync();

            if (response == null)
            { return defult; }

            return response.main.temp;
        }
    }
}
