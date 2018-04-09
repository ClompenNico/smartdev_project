using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core.Models
{
    public class Currently
    {
        [JsonProperty(PropertyName = "time")]
        public long Time { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "temperature")]
        public double Temperature { get; set; }
        
        /*
        public double temperature
        {
            get { return Math.Round(Temperature); }
        }
        

        public double apparentTemperature { get; set; }
        */
    }
}
