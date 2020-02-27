namespace StarWarsTravelCalculator.Logic
{
    public static class ShipTravelCalculator
    {
        public static int CalculateJumpsForDistance(long speed, long hoursOfConsumables, long distance)
        {
            return (int)(distance / (speed * hoursOfConsumables));
        }
    }
}