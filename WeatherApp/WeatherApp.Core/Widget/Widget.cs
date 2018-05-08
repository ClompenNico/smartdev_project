using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Models;

namespace WeatherApp.Core.Widget
{
    public class Widget
    {
        public const string _API_KEY = "eb2489e479f0bc360823f38d47e6f7fb";

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

        private const string _BASEURL = "https://api.darksky.net/forecast/";
        string _PARAMETER = "units=auto";

        //DEZE GLOBALE VARIABELEN NIET VERGETEN PLAATSEN!   GlobalVariables._LATITUDE   GlobalVariables._LONGITUDE
        double latitude = 50;
        double longitude = 3;

        public Task<Weather> GetWeather()
        {
            string url = String.Format("{0}{1}/{2},{3}?{4}", _BASEURL, _API_KEY, latitude, longitude, _PARAMETER);
            return GetAsync<Weather>(url);
        }



    }
}
