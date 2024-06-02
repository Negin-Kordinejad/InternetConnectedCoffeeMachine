using InternetConnectedCoffeeMachine.Application.Models;

namespace InternetConnectedCoffeeMachine.Application.Services
{
    public interface ICoffeeService
    {
        Task<CoffeeModel> GetCoffeeAsync();
    }
}
