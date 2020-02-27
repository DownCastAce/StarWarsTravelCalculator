using System;
using System.Text.Json;
using StarWarsTravelCalculator.Handlers;
using StarWarsTravelCalculator.Models;
using StarWarsTravelCalculator.Services;

namespace StarWarsTravelCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IRestClient client = new RestClient();
            IHandler handler = new Handler(client);

            var result = handler.RetrieveAll<Starship>();
            
            Console.WriteLine(JsonSerializer.Serialize(result.Results));
        }
    }
}