using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NMCT.Resto.Core.Repositories
{
    public class BaseRepository
    {
        public const string _API_KEY = "eb2489e479f0bc360823f38d47e6f7fb/";

        private HttpClient CreateHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("user-key", _API_KEY);
            return client;
        }

        protected async Task<T> GetAsync<T>(string url)
        {
            using (HttpClient client = CreateHttpClient())
            {
                try
                {
                    var json = await client.GetStringAsync(url);
                    return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return default(T);
                }
            }
        }

        protected async Task<T> PostAsync<T>(string url, object data)
        {
            using (HttpClient client = CreateHttpClient())
            {
                var json = JsonConvert.SerializeObject(data);

                try
                {
                    var result = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                    if (result.IsSuccessStatusCode)
                        return await Task.Run(() => JsonConvert.DeserializeObject<T>(result.Content.ToString()));

                    return default(T);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return default(T);
                }
            }
        }
    }
}
