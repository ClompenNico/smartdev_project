using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Models;
using WeatherApp.Core.Services;

namespace WeatherApp.Core.ViewModels
{
    public class WeatherTabsViewModel : MvxViewModel
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

        protected readonly IWeatherService _weatherService;
        //create a lazy instance for each viewmodel of the tabs in the tabview
        private readonly Lazy<WeatherViewModel> _weatherViewModel;
        private readonly Lazy<TabDetailsViewModel> _tabDetailsViewModel;

        //property to access value of the lazy instance
        public WeatherViewModel WeatherVM => _weatherViewModel.Value;
        public TabDetailsViewModel TabDetailsVM => _tabDetailsViewModel.Value;

        public WeatherTabsViewModel(IWeatherService weatherService)
        {
            this._weatherService = weatherService;

            //GetWeatherData();

            //initialize lazy instance via ioc construct
            _weatherViewModel = new Lazy<WeatherViewModel>(Mvx.IocConstruct<WeatherViewModel>);
            _tabDetailsViewModel = new Lazy<TabDetailsViewModel>(Mvx.IocConstruct<TabDetailsViewModel>);

            
        }

        public async void GetWeatherData()
        {

        }
    }
}
