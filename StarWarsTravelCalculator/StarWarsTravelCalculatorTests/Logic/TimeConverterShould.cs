using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsTravelCalculator.Constants;
using StarWarsTravelCalculator.Logic;

namespace StarWarsTravelCalculatorTests.Logic
{
    [TestClass]
    public class TimeConverterShould
    {
        [TestMethod]
        public void Convert_One_Day_To_Hour_Equivalent()
        {
            string testData = $"1 {TimeFrame.Day}";

            long expected = 24;
            long actual = TimeConverter.ConvertTimeFrameToHours(testData);
            
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Convert_Multiple_Days_To_Hour_Equivalent()
        {
            string testData = $"5 {TimeFrame.Days}";

            long expected = 120;
            long actual = TimeConverter.ConvertTimeFrameToHours(testData);
            
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Convert_One_Week_To_Hour_Equivalent()
        {
            string testData = $"1 {TimeFrame.Week}";

            long expected = 168;
            long actual = TimeConverter.ConvertTimeFrameToHours(testData);
            
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Convert_Multiple_Weeks_To_Hour_Equivalent()
        {
            string testData = $"5 {TimeFrame.Weeks}";

            long expected = 840;
            long actual = TimeConverter.ConvertTimeFrameToHours(testData);
            
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Convert_One_Month_To_Hour_Equivalent()
        {
            string testData = $"1 {TimeFrame.Month}";

            long expected = 720;
            long actual = TimeConverter.ConvertTimeFrameToHours(testData);
            
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Convert_Multiple_Months_To_Hour_Equivalent()
        {
            string testData = $"5 {TimeFrame.Months}";

            long expected = 3600;
            long actual = TimeConverter.ConvertTimeFrameToHours(testData);
            
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Convert_One_Year_To_Hour_Equivalent()
        {
            string testData = $"1 {TimeFrame.Year}";

            long expected = 8760;
            long actual = TimeConverter.ConvertTimeFrameToHours(testData);
            
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Convert_Multiple_Years_To_Hour_Equivalent()
        {
            string testData = $"5 {TimeFrame.Years}";

            long expected = 43800;
            long actual = TimeConverter.ConvertTimeFrameToHours(testData);
            
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Give_Negative_Value_For_Unknown_Lower_Case()
        {
            string testData = DefaultValues.Unknown;

            long expected = -1;
            long actual = TimeConverter.ConvertTimeFrameToHours(testData);
            
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Give_Negative_Value_For_Unknown_Random_Case()
        {
            string testData = "uNkNOwn";

            long expected = -1;
            long actual = TimeConverter.ConvertTimeFrameToHours(testData);
            
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Give_Negative_Number_For_Bad_Input()
        {
            string testData = "------- -------";

            long actual = TimeConverter.ConvertTimeFrameToHours(testData);
            
            Assert.IsTrue(actual <= -1);
        }
    }
}