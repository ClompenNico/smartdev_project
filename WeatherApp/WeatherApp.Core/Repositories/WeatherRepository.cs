using NMCT.Resto.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Models;

namespace WeatherApp.Core.Repositories
{
    public class WeatherRepository : BaseRepository, IWeatherRepository
    {
        private const string _BASEURL = "https://api.darksky.net/forecast/";
        private const string _COORDINATES = "37.8267,-122.4233";
        /*
        private const double latitude = 37.8267;
        private const double longitude = -122.4233;
        */

        public Task<Weather>GetWeather()
        {
            string url = String.Format("{0}{1}{2}", _BASEURL, _API_KEY, _COORDINATES);
            return GetAsync<Weather>(url);
        }

    }
}
