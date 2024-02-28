
namespace EtlUpload
{
    public interface IUploadServiceBase<T>
    {
        Task<IAsyncEnumerable<T>?> GetDataFromAPI(Uri uri, Dictionary<string, string> parameters);
    }
}