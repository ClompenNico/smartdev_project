using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core.Models
{
    public class Minutely
    {
        //WEATHER PAGE
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }
    }
}
