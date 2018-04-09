using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Models;
using WeatherApp.Core.Services;

namespace WeatherApp.Core.ViewModels
{
    public class WeatherViewModel : MvxViewModel
    {
        protected readonly IWeatherService _weatherService;
        public WeatherViewModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
            LoadData();
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

        public async void LoadData()
        {
            Weather = await _weatherService.GetWeather();
        }

    }
}
