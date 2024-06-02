namespace InternetConnectedCoffeeMachine.Application.Services
{
    public interface IDateTimeProvider
    { 
        DateTime Now { get; }
    }
}
