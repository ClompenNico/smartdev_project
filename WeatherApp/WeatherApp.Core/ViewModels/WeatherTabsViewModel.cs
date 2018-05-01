using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
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
        
        //Luisteren naar het bericht met de locatie
        private readonly IMvxMessenger _messenger;
        private readonly MvxSubscriptionToken _token;

        private readonly IMvxNavigationService _navigationService;
        protected readonly IWeatherService _weatherService;
        //create a lazy instance for each viewmodel of the tabs in the tabview
        private readonly Lazy<WeatherViewModel> _weatherViewModel;
        private readonly Lazy<TabDetailsViewModel> _tabDetailsViewModel;
        private readonly Lazy<TabWeekViewModel> _tabWeekTableViewModel;

        //property to access value of the lazy instance
        public WeatherViewModel WeatherVM => _weatherViewModel.Value;
        public TabDetailsViewModel TabDetailsVM => _tabDetailsViewModel.Value;
        public TabWeekViewModel TabWeekVM => _tabWeekTableViewModel.Value;

        

        public WeatherTabsViewModel(IWeatherService weatherService, IMvxNavigationService navigationService, IMvxMessenger messenger)
        {
            //Subcriben aan de locatiemessage
            _messenger = messenger;
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);

            //OnLocationMessage();

            //Navigeren
            _navigationService = navigationService;

            //Weer service
            this._weatherService = weatherService;

            //Data opvragen
           

            //initialize lazy instance via ioc construct
            _weatherViewModel = new Lazy<WeatherViewModel>(Mvx.IocConstruct<WeatherViewModel>);
            _tabDetailsViewModel = new Lazy<TabDetailsViewModel>(Mvx.IocConstruct<TabDetailsViewModel>);
            _tabWeekTableViewModel = new Lazy<TabWeekViewModel>(Mvx.IocConstruct<TabWeekViewModel>);


        }

        private void OnLocationMessage(LocationMessage message)
        {
            GlobalVariables._LATITUDE = message.Latitude;
            GlobalVariables._LONGITUDE = message.Longitude;
            GetWeatherData();
        }

        public async void GetWeatherData()
        {
            Weather = await _weatherService.GetWeather();

            WeatherVM.Weather = this.Weather;
            TabDetailsVM.Weather = this.Weather;
            TabWeekVM.Weather = this.Weather;
        }

        public IMvxCommand NotificationsCommand
        {
            get
            {
                return new MvxCommand(Notifications);
            }
        }

        public void Notifications()
        {
            _navigationService.Navigate<NotificationsViewModel>();
        }
    }
}
