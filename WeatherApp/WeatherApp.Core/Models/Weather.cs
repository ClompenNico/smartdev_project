using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core.Models
{
    public class Weather
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string timezone { get; set; }
        //public Currently currently { get; set; }
    }
}
