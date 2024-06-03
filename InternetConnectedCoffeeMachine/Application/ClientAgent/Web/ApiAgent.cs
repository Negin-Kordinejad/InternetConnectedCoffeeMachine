using Newtonsoft.Json;

namespace InternetConnectedCoffeeMachine.Application.ClientAgent.Web
{
    public class ApiAgent
    {
        private readonly IHttpService _httpService;

        public ApiAgent(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public virtual async Task<string> GetApiAsync(string endpoint, string function)
        {
            var url = $"{endpoint}/{function}";
            return await _httpService.Get(url);
        }

        public virtual T ToObject<T>(string jsonResponse)
        {
            return JsonConvert.DeserializeObject<T>(jsonResponse)! ;
        }
    }
}
