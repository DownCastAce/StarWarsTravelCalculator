namespace StarWarsTravelCalculator.Logic
{
    public static class ShipTravelCalculator
    {
        /// <summary>
        /// Calculates the amount of jumps required for a given distance, speed and hours of consumables
        /// Distance is in MGLT. Speed in MGLT per Hour. 
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="hoursOfConsumables"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static int CalculateJumpsForDistance(long speed, long hoursOfConsumables, long distance)
        {
            return (int)(distance / (speed * hoursOfConsumables));
        }
    }
}