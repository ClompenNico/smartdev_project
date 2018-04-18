using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core.Models
{
    public class Weather
    {
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }
        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }
        [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }

        [JsonProperty(PropertyName = "currently")]
        public Currently Currently { get; set; }

        [JsonProperty(PropertyName = "minutely")]
        public Minutely Minutely { get; set; }

        //[JsonProperty(PropertyName = "daily")]
        //public Daily Daily { get; set; }
    }
}
