using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Messages;
using WeatherApp.Core.Models;
using WeatherApp.Core.Services;

namespace WeatherApp.Core.ViewModels
{
    public class WeatherViewModel : MvxViewModel
    {
        double _LATITUDE;
        double _LONGITUDE;
        private readonly IMvxMessenger _messenger;
        private readonly MvxSubscriptionToken _token;

        protected readonly IWeatherService _weatherService;
        public WeatherViewModel(IWeatherService weatherService, IMvxMessenger messenger)
        {
            _messenger = messenger;
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
            _weatherService = weatherService;
            //LoadData();
        }

        private Weather _weather;
        public Weather Weather
        {
            get { return _weather; }
            set
            {
                _weather = value;
                RaisePropertyChanged(() => Weather);
            }
        }

        private void OnLocationMessage(LocationMessage message)
        {
            _LATITUDE = message.Latitude;
            _LONGITUDE = message.Longitude;
            //LoadData();
        }
        
        public async void LoadData()
        {
            Weather = await _weatherService.GetWeather();
        }
    }
}
