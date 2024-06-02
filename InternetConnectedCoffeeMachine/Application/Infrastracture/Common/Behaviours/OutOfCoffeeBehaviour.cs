using InternetConnectedCoffeeMachine.Application.Models;
using InternetConnectedCoffeeMachine.Application.Services;
using MediatR;

namespace InternetConnectedCoffeeMachine.Application.Infrastracture.Common.Behaviours
{
    public class OutOfCoffeeBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ICoffeeCountService _coffeeCountService;

        public OutOfCoffeeBehaviour(ICoffeeCountService coffeeCountService)
        {
            _coffeeCountService = coffeeCountService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is Response<CoffeeModel> rc && !rc.IsSuccessful)
            {
                return await next();
            }

            if (_coffeeCountService.GetCoffeeCallCount() == 0)
            {
                return (TResponse)(object)new Response<CoffeeModel>()
                {
                    Data = null,
                    StatusCode = StatusCodes.Status503ServiceUnavailable,
                    IsSuccessful = false,
                };
            }

            return await next();

        }
    }
}
