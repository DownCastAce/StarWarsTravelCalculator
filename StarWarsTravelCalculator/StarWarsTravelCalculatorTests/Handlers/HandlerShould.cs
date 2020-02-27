using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Text.Json;
using StarWarsTravelCalculator.Handlers;
using StarWarsTravelCalculator.Models;
using StarWarsTravelCalculator.Services;

namespace StarWarsTravelCalculatorTests.Handlers
{
    [TestClass]
    public class HandlerShould
    {
        private const string Expected = "{\"count\":37,\"next\":\"https://swapi.co/api/starships/?page=2\",\"previous\":null,\"results\":[{\"name\":\"Executor\",\"consumables\":\"6 years\",\"MGLT\":\"40\"}]}";

        [TestMethod]
        public void Retrieve_A_Star_Ship()
        {
            Mock<IRestClient> fakeClient = new Mock<IRestClient>();
            fakeClient.Setup(x => x.Get(It.IsAny<string>())).Returns(Expected);
            
            Handler testEngine = new Handler(fakeClient.Object);
            var actual = testEngine.RetrieveAll<Starship>();
            
            Assert.AreEqual(Expected, JsonSerializer.Serialize(actual));
        }
    }
}