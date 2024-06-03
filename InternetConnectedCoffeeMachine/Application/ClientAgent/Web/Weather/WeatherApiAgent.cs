namespace InternetConnectedCoffeeMachine.Application.ClientAgent.Web.Weather
{
    public class WeatherApiAgent : ApiAgent, IWeatherApiAgent
    {
        private readonly string _url;
        private readonly string _function;
        private readonly string _key;
        private readonly string _lat;
        private readonly string _lon;
        public WeatherApiAgent(IConfiguration config, IHttpService httpService)
            : base(httpService)
        {
            var weatherApiInfo = config.GetSection("WeatherApiInfo").AsEnumerable(true).ToDictionary(d => d.Key, d => d.Value);
            _url = weatherApiInfo["url"]!;
            _function= weatherApiInfo["function"]!;
            _key = weatherApiInfo["key"]!;
            _lat = weatherApiInfo["lat"]!;
            _lon = weatherApiInfo["lon"]!;
        }

        public async Task<WeatherResponse> GetCurrentTemperatureAsync()
        {
            var function = string.Format(_function, _lat, _lon, _key);

            var response = await GetApiAsync(_url, function);

            return ToObject<WeatherResponse>(response);
        }

    }
}
