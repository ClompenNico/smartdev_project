using MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core.Messages
{
    public class LocationMessage : MvxMessage
    {
        public LocationMessage(object sender, double lat, double lng) : base(sender)
        {
            Latitude = lat;
            Longitude = lng;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
