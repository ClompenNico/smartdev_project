using System;

using NotificationCenter;
using Foundation;
using Social;
using UIKit;
using WeatherApp.Core.Models;
using WeatherApp.Core.Services;
using CoreLocation;
using WeatherApp.Core.Repositories;

namespace WeatherApp.Widget
{
    public partial class TodayViewController : SLComposeServiceViewController, INCWidgetProviding
    {
        public Weather _weather;
        public Weather Weather
        {
            get { return _weather; }
            set
            {
                _weather = value;
            }
        }

        public TodayViewController(IntPtr handle) : base(handle)
        {
        }

        protected readonly IWeatherService _weatherService;

        public TodayViewController(IWeatherService weatherService)
        {
            this._weatherService = weatherService;
        }

        //Luisteren naar het bericht met de locatie
        //private readonly IMvxMessenger _messenger;
        //private readonly MvxSubscriptionToken _token;

        /*
        public TodayViewController(IWeatherService weatherService)
        {
            this._weatherService = weatherService;
        }
        */

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //functie locatie
            GetLocation();
            //GetWeatherData();
            //lblVandaag.Text = currentTemperatuur;

            // Do any additional setup after loading the view.
        }


        //locatie opvragen
        private void GetLocation()
        {
            CLLocationManager locationManager = new CLLocationManager();
            locationManager.StartUpdatingLocation();
            locationManager.StartUpdatingHeading();

            locationManager.LocationsUpdated += delegate (object sender, CLLocationsUpdatedEventArgs e)
            {
                foreach (CLLocation loc in e.Locations)
                {
                    GetWeatherData(loc.Coordinate.Latitude, loc.Coordinate.Longitude);
                }
            };
        }

        public async void GetWeatherData(double Latitude, double Longitude)
        {
            //Globale variabelen opvullen met de meegegeven latitude & longitude 
            //double LONGITUDE = Longitude;
            //double LATITUDE = Latitude;

            GlobalVariables._LATITUDE = Latitude;
            GlobalVariables._LONGITUDE = Longitude;

            //Repository nodig voor weer op te vragen
            WeatherRepository weatherRepository = new WeatherRepository();

            //get weather in object plaatsen
            Weather weather = await weatherRepository.GetWeather();

            //Weather = await _weatherService.GetWeather();

            //labels opvullen
            lblTemperatuur.Text = weather.Currently.Temp;
            lblSummary.Text = weather._Daily.Summary;

            //lblTemperatuur.Text = Weather.Currently.Temp;

            //string currentTemperatuur = Weather.Currently.Temp;

        }

        public void WidgetPerformUpdate(Action<NCUpdateResult> completionHandler)
        {
            // Perform any setup necessary in order to update the view.

            // If an error is encoutered, use NCUpdateResultFailed
            // If there's no update required, use NCUpdateResultNoData
            // If there's an update, use NCUpdateResultNewData

            completionHandler(NCUpdateResult.NewData);
        }
    }
}
