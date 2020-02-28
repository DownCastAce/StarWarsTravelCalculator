using System.Text.Json;
using StarWarsTravelCalculator.Constants;
using StarWarsTravelCalculator.Models;
using StarWarsTravelCalculator.Services;

namespace StarWarsTravelCalculator.Handlers
{
    /// <summary>
    /// Generic Handler to help process the response of the API call
    /// </summary>
    public class Handler : IHandler
    {
        private IRestClient _restClient;

        public Handler(IRestClient restClient)
        {
            _restClient = restClient;
        }
        
        /// <summary>
        /// Will retrieve all records of the type provided from the endpoint provided
        /// </summary>
        /// <param name="endpoint"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public SwApiResults<T> RetrieveAll<T>(string endpoint)
        {
            string response = _restClient.Get($"{StarWarsApiEndpoints.BaseEndpoint}{endpoint}");

            SwApiResults<T> result = JsonSerializer.Deserialize<SwApiResults<T>>(response);

            while (!string.IsNullOrWhiteSpace(result.Next))
            {
                string paginatedResponse = _restClient.Get(result.Next);
                SwApiResults<T> paginatedResult = JsonSerializer.Deserialize<SwApiResults<T>>(paginatedResponse);
                result.Results.AddRange(paginatedResult.Results);
                result.Next = paginatedResult.Next;
            }

            return result;
        }
    }
}