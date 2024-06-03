namespace InternetConnectedCoffeeMachine.Application.ClientAgent.Web
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;

        public HttpService(IHttpClientFactory httpClient) 
        {
            _client = httpClient.CreateClient();
        }

        public async Task<string> Get(string url)
        {

            var httpResponse = await _client.GetAsync(url);

            httpResponse.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadAsStringAsync();
        }
    }
}
