using DAO;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;


namespace ETLClient
{
    public class ServiceApi : IServiceApi
    {
        IRepositoryBase _repositoryBase;

        public ServiceApi(IRepositoryBase repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        private static HttpClient CreateDefaultHttpClient(Uri baseAddress)
        {
            var client = new HttpClient
            {
                BaseAddress = baseAddress,
            };

            return client;
        }


        private static string UrlGetParams(Dictionary<string, string> urlParameters)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var key in urlParameters)
            {
                stringBuilder.Append($"{key.Key}={System.Web.HttpUtility.UrlEncode(key.Value)}&");
            }

            return stringBuilder.ToString();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="urlParameters"></param>
        /// <returns></returns>
        public async Task<IAsyncEnumerable<Universitet>> GetData(string url, Dictionary<string, string> urlParameters)
        {
            Uri uri = new Uri("http://universities.hipolabs.com/search");
            string UrlParameters = "?country=Russian+Federation";

            var client = CreateDefaultHttpClient(uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;
            // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var universitets = response.Content.ReadFromJsonAsAsyncEnumerable<Universitet>();  //Make sure to add a reference to System.Net.Http.Formatting.dll

                return universitets;

                //_repositoryBase.AddRange<Universitet>((IEnumerable<Universitet>)universitets);
                //await _repositoryBase.SaveChangesAsync();

            }
            return null;
        }



    }
}
