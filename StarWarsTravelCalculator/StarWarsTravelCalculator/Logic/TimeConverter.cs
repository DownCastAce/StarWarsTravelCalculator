using System;
using System.Globalization;

namespace StarWarsTravelCalculator.Logic
{
    public static class TimeConverter
    {
        private const string Unknown = "unknown";
        private static int hoursInADay = 24;
        private static int daysInAMonth = 30;
        private static int daysInAYear = 365;
        
        public static long ConvertTimeFrameToHours(string timeFrame)
        {
            if (timeFrame.Equals(Unknown, StringComparison.OrdinalIgnoreCase))
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
            return timeFrame.ToLower(CultureInfo.InvariantCulture) switch
            {
                "day" => hoursInADay,
                "days" => hoursInADay,
                "week" => (hoursInADay * 7),
                "weeks" => (hoursInADay * 7),
                "month" => (daysInAMonth * hoursInADay),
                "months" => (daysInAMonth * hoursInADay),
                "year" => (daysInAYear * hoursInADay),
                "years" => (daysInAYear * hoursInADay),
                _ => -1
            };
        }
    }
}