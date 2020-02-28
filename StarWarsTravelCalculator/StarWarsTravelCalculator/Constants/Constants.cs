namespace StarWarsTravelCalculator.Constants
{
    public static class DefaultValues
    {
        public const string Unknown = "UNKNOWN";
    }
    
    public static class TimeFrame
    {
        public const string Day = "day";
        public const string Days = "days";
        public const string Week = "week";
        public const string Weeks = "weeks";
        public const string Month = "month";
        public const string Months = "months";
        public const string Year = "year";
        public const string Years = "years";
        
        public const int HoursInADay = 24;
        public const int DaysInAMonth = 30;
        public const int DaysInAYear = 365;
    }

    public static class StarWarsApiEndpoints
    {
        public const string BaseEndpoint = "https://swapi.co/api/";
        public const string Starships = "starships";
    }
}