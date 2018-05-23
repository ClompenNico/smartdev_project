using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Messages;

namespace WeatherApp.Core.Services
{
    public class LocationService : ILocationService
    {
        private readonly IMvxLocationWatcher _watcher;
        private readonly IMvxMessenger _messenger;

        //DI
        public LocationService(IMvxLocationWatcher watcher, IMvxMessenger messenger)
        {
            _watcher = watcher;
            _messenger = messenger;
            _watcher.Start(new MvxLocationOptions(), OnLocation, OnError);
        }

        //LOCATIE MEEGEVEN (NODIG VOOR IN DE MESSAGE)
        private void OnLocation(MvxGeoLocation location)
        {
            //MESSAGE OPVULLEN
            var message = new LocationMessage(this,
                                                location.Coordinates.Latitude,
                                                location.Coordinates.Longitude
                                                );

            //MESSAGE PUBLISHEN
            _messenger.Publish(message);
        }

        //ERROR
        private void OnError(MvxLocationError error)
        {
            Mvx.Error("Seen location error {0}", error.Code);
        }
    }
}
