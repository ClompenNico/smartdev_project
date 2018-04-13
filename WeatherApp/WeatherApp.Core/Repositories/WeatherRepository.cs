using MvvmCross.Plugins.Messenger;
using NMCT.Resto.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Messages;
using WeatherApp.Core.Models;

namespace WeatherApp.Core.Repositories
{
    public class WeatherRepository : BaseRepository, IWeatherRepository
    {
        private const string _BASEURL = "https://api.darksky.net/forecast/";
        //private const string _COORDINATES = "37.8267,-122.4233";
        double _LATITUDE = 50.815474;         //private const     37.8267
        double _LONGITUDE = 3.2718397999999524;      //private const     -122.4233
        string _PARAMETER = "units=auto";

        /*
        private readonly IMvxMessenger _messenger;
        private readonly MvxSubscriptionToken _token;
        public WeatherRepository(IMvxMessenger messenger)
        {
            _messenger = messenger;
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
        }

        private void OnLocationMessage(LocationMessage message)
        {
            _LATITUDE = message.Latitude;
            _LONGITUDE = message.Longitude;
        }
        */

        public Task<Weather>GetWeather()
        {
            string url = String.Format("{0}{1}/{2},{3}?{4}", _BASEURL, _API_KEY, _LATITUDE, _LONGITUDE, _PARAMETER);
            return GetAsync<Weather>(url);
        }

    }
}
