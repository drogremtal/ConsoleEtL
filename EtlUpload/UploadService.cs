using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace EtlUpload
{
    public class UploadService : IUploadService
    {
        public async Task<IAsyncEnumerable<T?>?> GetDataFromAPI<T>(Uri uri, Dictionary<string, string> parameters)
        {
            using (var client = new HttpClient())
            {

                var urlParams = "?" + string.Join("&", parameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(urlParams).Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadFromJsonAsAsyncEnumerable<T?>();
                    return data;
                }
            }

            return null;
        }


    }
}
