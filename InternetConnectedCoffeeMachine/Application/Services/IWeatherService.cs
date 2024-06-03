namespace InternetConnectedCoffeeMachine.Application.Services
{
    public interface IWeatherService
    {
        Task <float> GetCurrentTemperature();
    }
}
