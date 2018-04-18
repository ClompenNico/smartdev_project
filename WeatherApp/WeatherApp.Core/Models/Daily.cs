using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core.Models
{
    public class Daily
    {
        [JsonProperty(PropertyName = "data")]
        public DailyData DailyData { get; set; }
    }
}
