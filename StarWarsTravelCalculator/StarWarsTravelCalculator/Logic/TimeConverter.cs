using System;
using StarWarsTravelCalculator.Constants;

namespace StarWarsTravelCalculator.Logic
{
    public static class TimeConverter
    {
        
        /// <summary>
        /// Convert the timeFrame into hours
        /// Expected input is "{AmountOf} {Days|Weeks|Months|Years}"
        /// </summary>
        /// <param name="timeFrame"></param>
        /// <returns></returns>
        public static long ConvertTimeFrameToHours(string timeFrame)
        {
            if (timeFrame.Equals(DefaultValues.Unknown, StringComparison.OrdinalIgnoreCase))
            {
                return -1;
            }
            
            string[] test = timeFrame.Trim().Split(" ");
            
            long hours = GetHoursEquivalent(test[1]);

            long multiplier = RetrieveMultiplier(test[0]);

            if (hours <= -1 || multiplier <= -1)
            {
                return -1;
            }
            
            return multiplier * hours;
        }

        private static long RetrieveMultiplier(string test)
        {
            return long.TryParse(test, out long result) ? result : -1;
        }

        private static long GetHoursEquivalent(string timeFrame)
        {
            return timeFrame.ToLowerInvariant() switch
            {
                TimeFrame.Day => TimeFrame.HoursInADay,
                TimeFrame.Days => TimeFrame.HoursInADay,
                TimeFrame.Week => (TimeFrame.HoursInADay * 7),
                TimeFrame.Weeks => (TimeFrame.HoursInADay * 7),
                TimeFrame.Month => (TimeFrame.DaysInAMonth * TimeFrame.HoursInADay),
                TimeFrame.Months => (TimeFrame.DaysInAMonth * TimeFrame.HoursInADay),
                TimeFrame.Year => (TimeFrame.DaysInAYear * TimeFrame.HoursInADay),
                TimeFrame.Years => (TimeFrame.DaysInAYear * TimeFrame.HoursInADay),
                _ => -1
            };
        }
    }
}