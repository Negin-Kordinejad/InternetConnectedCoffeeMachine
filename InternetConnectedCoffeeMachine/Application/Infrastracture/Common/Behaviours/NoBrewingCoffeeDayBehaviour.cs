using InternetConnectedCoffeeMachine.Application.Models;
using InternetConnectedCoffeeMachine.Application.Services;
using MediatR;

namespace InternetConnectedCoffeeMachine.Application.Infrastracture.Common.Behaviours
{
    public class NoBrewingCoffeeDayBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public NoBrewingCoffeeDayBehaviour(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
                var today = _dateTimeProvider.Now;
                if (today.Day == Constants.Dates.NotWorkingDate.Day && today.Month == Constants.Dates.NotWorkingDate.Month)
                {
                    return (TResponse)(object)new Response<CoffeeModel>()
                    {
                        Data = null,
                        StatusCode = StatusCodes.Status418ImATeapot,
                        IsSuccessful = false,
                    };
                }

            return await next();

        }
    }
}
