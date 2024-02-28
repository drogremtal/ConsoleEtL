
namespace ETLClient
{
    public interface IServiceApi
    {
        Task<IAsyncEnumerable<Universitet>> GetData(string url, Dictionary<string, string> urlParameters);
    }
}