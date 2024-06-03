using InternetConnectedCoffeeMachine.Application.Models;
using InternetConnectedCoffeeMachine.Application.Services;
using MediatR;

namespace InternetConnectedCoffeeMachine.Application.Infrastracture.Common.Behaviours
{
    public class WeatherBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IWeatherService _weatherService;
        private readonly IDateTimeProvider _dateTimeProvider;

        public WeatherBehaviour(IWeatherService weatherService, IDateTimeProvider dateTimeProvider)
        {
            _weatherService = weatherService;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var currentTemp = await _weatherService.GetCurrentTemperature();
            if (currentTemp > Constants.Weather.TemperatureInC)
            {
                string IsoDateTime = _dateTimeProvider.Now.ToString(Constants.Format.ISO8601Format);
                var data = new CoffeeModel
                {
                    Message = Constants.Weather.IcedCoffeeReadyMessage,
                    Prepared = IsoDateTime
                };
                return (TResponse)(object)new Response<CoffeeModel>()
                {
                    Data = data,
                    StatusCode = StatusCodes.Status200OK,
                    IsSuccessful = true,
                };
            }

            return await next();
        }
    }
}
