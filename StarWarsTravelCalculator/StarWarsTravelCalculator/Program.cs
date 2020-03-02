using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Autofac;
using StarWarsTravelCalculator.Constants;
using StarWarsTravelCalculator.Handlers;
using StarWarsTravelCalculator.Logic;
using StarWarsTravelCalculator.Models;
using StarWarsTravelCalculator.Services;

namespace StarWarsTravelCalculator
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static IContainer Container;
        
        public static void Main(string[] args)
        {
            Container = CreateContainer();
            IHandler handler = Container.Resolve<IHandler>();
            
            Console.Write("Enter the Distance to travel : ");
            bool correctInput = long.TryParse(Console.ReadLine(), out long distance);

            if (!correctInput || distance < 0)
            {
                Console.WriteLine("Incorrect Input!");
                return;
            }
            
            IList<Starship> result = handler.RetrieveAll<Starship>(StarWarsApiEndpoints.Starships).Results;

            foreach (Starship starship in result)
            {
                if (starship.MegaLights.Equals(DefaultValues.Unknown, StringComparison.OrdinalIgnoreCase) ||
                    starship.Consumables.Equals(DefaultValues.Unknown, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{starship.Name} : {DefaultValues.Unknown}");
                }
                else
                {
                    int jumps = ShipTravelCalculator.CalculateJumpsForDistance(long.Parse(starship.MegaLights), TimeConverter.ConvertTimeFrameToHours(starship.Consumables), distance);
                    Console.WriteLine($"{starship.Name} : {jumps}");   
                }
            }
        }
        
        /// <summary>
        /// Takes care of Dependency Injection
        /// </summary>
        /// <returns></returns>
        private static IContainer CreateContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //Setup Dependencies
            builder.RegisterType<RestClient>().As<IRestClient>().SingleInstance();
            builder.RegisterType<Handler>().As<IHandler>().SingleInstance();

            return builder.Build();
        }
    }
}