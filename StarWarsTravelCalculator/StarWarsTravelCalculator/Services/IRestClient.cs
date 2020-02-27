namespace StarWarsTravelCalculator.Services
{
    public interface IRestClient
    {
        string Get(string apiEndpoint);
    }
}