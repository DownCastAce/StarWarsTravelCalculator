using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsTravelCalculator.Logic;

namespace StarWarsTravelCalculatorTests.Logic
{
    [TestClass]
    public class ShipTravelCalculatorShould
    {
        [TestMethod]
        public void Get_One_Jump()
        {
            long speed = 1;
            long hoursOfConsumables = 1;
            long distance = 1;

            int expected = 1;
            int actual = ShipTravelCalculator.CalculateJumpsForDistance(speed, hoursOfConsumables, distance);
            
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Get_Two_Jump()
        {
            long speed = 5;
            long hoursOfConsumables = 2;
            long distance = 20;

            int expected = 2;
            int actual = ShipTravelCalculator.CalculateJumpsForDistance(speed, hoursOfConsumables, distance);
            
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Get_Five_Jump_With_Non_One_Speed()
        {
            long speed = 25;
            long hoursOfConsumables = 2;
            long distance = 250;

            int expected = 5;
            int actual = ShipTravelCalculator.CalculateJumpsForDistance(speed, hoursOfConsumables, distance);
            
            Assert.AreEqual(expected, actual);
        }
        
    }
}