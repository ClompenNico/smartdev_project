using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core.Models
{
    public class DailyData
    {
        [JsonProperty(PropertyName = "time")]
        public long Time { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "temperatureHigh")]
        public double TemperatureHigh { get; set; }

        [JsonProperty(PropertyName = "temperatureLow")]
        public double TemperatureLow { get; set; }

    }
}
