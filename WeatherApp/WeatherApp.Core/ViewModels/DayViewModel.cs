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
    public class DayViewModel : MvxViewModel
    {
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

        //service aan spreken
        protected readonly IWeatherService _weatherService;


        public DayViewModel()
        {
            
        }

        /*
        public async void Init(string dayTime)
        {
            this.Weather = await _weatherService.GetDayByTime(dayTime);
            GetDayData();
        }
        */

        /*
        public async void GetDayData()
        {

        }
        */
    }
}
