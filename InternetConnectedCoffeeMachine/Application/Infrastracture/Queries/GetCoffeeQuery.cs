using InternetConnectedCoffeeMachine.Application.Models;
using InternetConnectedCoffeeMachine.Application.Services;
using MediatR;

namespace InternetConnectedCoffeeMachine.Application.Infrastracture.Queries
{
    public class GetCoffeeQuery : IRequest<Response<CoffeeModel>>
    {

        public class Handler : IRequestHandler<GetCoffeeQuery, Response<CoffeeModel>>
        {
            private readonly ICoffeeService _coffeeService;

            public Handler(ICoffeeService coffeeService)
            {
                _coffeeService = coffeeService;
            }

            public async Task<Response<CoffeeModel>> Handle(GetCoffeeQuery request, CancellationToken cancellationToken)
            {
                var response = new Response<CoffeeModel>
                {
                    Data = await _coffeeService.GetCoffeeAsync(),
                    IsSuccessful = true,
                    StatusCode = StatusCodes.Status200OK
                };

                return response;

            }

        }
    }
}
