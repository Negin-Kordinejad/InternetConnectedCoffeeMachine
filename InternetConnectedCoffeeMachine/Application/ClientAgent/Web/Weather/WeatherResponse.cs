namespace InternetConnectedCoffeeMachine.Application.ClientAgent.Web.Weather
{
    public class WeatherResponse
    {
        public Main main { get; set; }

    }
    public class Main
    {
        public float temp { get; set; }
    }
}
