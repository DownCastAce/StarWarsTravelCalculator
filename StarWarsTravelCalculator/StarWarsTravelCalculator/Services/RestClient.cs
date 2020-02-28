using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace StarWarsTravelCalculator.Services
{
    [ExcludeFromCodeCoverage]
    public class RestClient : IRestClient
    {
        private static readonly HttpClient Client = new HttpClient();
        
        /// <summary>
        /// Rest GET call to the API endpoint provided
        /// </summary>
        /// <param name="apiEndpoint"></param>
        /// <returns></returns>
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