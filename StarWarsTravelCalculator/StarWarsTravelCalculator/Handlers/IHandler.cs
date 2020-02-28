using StarWarsTravelCalculator.Models;

namespace StarWarsTravelCalculator.Handlers
{
    public interface IHandler
    {
        SwApiResults<T> RetrieveAll<T>(string endpoint);
    }
}