namespace InternetConnectedCoffeeMachine.Application.Models
{
    public class Response<T>
    {
        public T? Data { get; set; }

        public int StatusCode { get; set; }

        public bool IsSuccessful { get; set; }
    }
}