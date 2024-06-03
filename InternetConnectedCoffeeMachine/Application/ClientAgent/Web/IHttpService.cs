namespace InternetConnectedCoffeeMachine.Application.ClientAgent.Web
{
    public interface IHttpService
    {
        Task<string> Get(string url);
    }
}
