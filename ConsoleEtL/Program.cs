using ETLClient;
using EtlUpload;
using System.Net.Http.Headers;
using System.Net.Http.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Uri uri = new Uri("http://universities.hipolabs.com/search");

        Dictionary<string, string> parameters = new Dictionary<string, string>() { { "country", "Russian Federation" } };///country=Russian+Federation

        var uploadService = new UploadService();

        var dataList = await uploadService.GetDataFromAPI<Universitet>(uri, parameters);

       await foreach (var item in dataList)
        {
            Console.WriteLine(item.ToString());
        }

    }

}