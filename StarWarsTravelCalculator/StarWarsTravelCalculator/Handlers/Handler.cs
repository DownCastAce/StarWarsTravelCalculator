using System.Text.Json;
using StarWarsTravelCalculator.Models;
using StarWarsTravelCalculator.Services;

namespace StarWarsTravelCalculator.Handlers
{
    public class Handler : IHandler
    {
        private string _apiEndpoint = "https://swapi.co/api/";
        private IRestClient _restClient;

        public Handler(IRestClient restClient)
        {
            _restClient = restClient;
        }
        
        public SwApiResults<T> RetrieveAll<T>()
        {
            string result = _restClient.Get(_apiEndpoint + "starships");

            return JsonSerializer.Deserialize<SwApiResults<T>>(result);
        }
    }
}