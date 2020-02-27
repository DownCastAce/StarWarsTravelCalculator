using System.Net.Http;

namespace StarWarsTravelCalculator.Services
{
    public class RestClient : IRestClient
    {
        private static readonly HttpClient Client = new HttpClient();
        
        public string Get(string apiEndpoint)
        {
            HttpResponseMessage response = Client.GetAsync(apiEndpoint).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }

            return string.Empty;
        }
    }
}