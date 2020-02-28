using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Text.Json;
using StarWarsTravelCalculator.Constants;
using StarWarsTravelCalculator.Handlers;
using StarWarsTravelCalculator.Models;
using StarWarsTravelCalculator.Services;

namespace StarWarsTravelCalculatorTests.Handlers
{
    [TestClass]
    public class HandlerShould
    {
        private const string Expected = "{\"count\":1,\"next\":null,\"previous\":null,\"results\":[{\"name\":\"Executor\",\"consumables\":\"6 years\",\"MGLT\":\"40\"}]}";
        private const string ApiResultWithPagination = "{\"count\":2,\"next\":\"https://swapi.co/api/starships/?page=2\",\"previous\":null,\"results\":[{\"name\":\"Death Star\",\"consumables\":\"3 years\",\"MGLT\":\"10\"}]}";

        private const string ExpectedMultipleShips = "{\"count\":2,\"next\":null,\"previous\":null,\"results\":[{\"name\":\"Death Star\",\"consumables\":\"3 years\",\"MGLT\":\"10\"},{\"name\":\"Executor\",\"consumables\":\"6 years\",\"MGLT\":\"40\"}]}";

        [TestMethod]
        public void Retrieve_A_Star_Ship()
        {
            Mock<IRestClient> fakeClient = new Mock<IRestClient>();
            fakeClient.Setup(x => x.Get(It.IsAny<string>())).Returns(Expected);
            
            Handler testEngine = new Handler(fakeClient.Object);
            var actual = testEngine.RetrieveAll<Starship>(DefaultValues.Unknown);
            
            Assert.AreEqual(Expected, JsonSerializer.Serialize(actual));
        }
        
        [TestMethod]
        public void Retrieve_Two_Star_Ship()
        {
            Mock<IRestClient> fakeClient = new Mock<IRestClient>();
            fakeClient.Setup(x => x.Get("https://swapi.co/api/starships")).Returns(ApiResultWithPagination);
            fakeClient.Setup(x => x.Get("https://swapi.co/api/starships/?page=2")).Returns(Expected);
            
            Handler testEngine = new Handler(fakeClient.Object);
            var actual = testEngine.RetrieveAll<Starship>("starships");
            
            Assert.AreEqual(ExpectedMultipleShips, JsonSerializer.Serialize(actual));
        }
    }
}