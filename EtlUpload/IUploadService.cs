
namespace EtlUpload
{
    public interface IUploadService
    {
        Task<IAsyncEnumerable<T>?> GetDataFromAPI<T>(Uri uri, Dictionary<string, string> parameters);
    }
}