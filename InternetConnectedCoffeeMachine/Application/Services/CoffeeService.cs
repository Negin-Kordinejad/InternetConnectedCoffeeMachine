using InternetConnectedCoffeeMachine.Application.Models;

namespace InternetConnectedCoffeeMachine.Application.Services
{
    public class CoffeeService : ICoffeeService
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public CoffeeService(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<CoffeeModel> GetCoffeeAsync()
        {
            string IsoDateTime = _dateTimeProvider.Now.ToString(Constants.Format.ISO8601Format);

            return new CoffeeModel
            {
                Message = Constants.Message.CoffeeReadyMessage,
                Prepared = IsoDateTime
            };
        }
    }
}
