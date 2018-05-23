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
        //WEATHER
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

        [JsonProperty(PropertyName = "hourly")]
        public Hourly _Hourly { get; set; }

        [JsonProperty(PropertyName = "daily")]
        public Daily _Daily { get; set; }

        public class Hourly
        {
            [JsonProperty(PropertyName = "summary")]
            public string Summary { get; set; }
        }


        //WEKELIJKS
        public class Daily
        {
            [JsonProperty(PropertyName = "summary")]
            public string Summary { get; set; }

            [JsonProperty(PropertyName = "icon")]
            public string Icon { get; set; }

            [JsonProperty(PropertyName = "data")]
            public List<DailyDatas> dailyDatas { get; set; }

            public class DailyDatas
            {
                [JsonProperty(PropertyName = "time")]
                public long Time { get; set; }

                public string Day
                {
                    get {
                        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        dtDateTime = dtDateTime.AddSeconds(Time);
                        return dtDateTime.DayOfWeek.ToString();
                    }

                    set { }
                }

                [JsonProperty(PropertyName = "summary")]
                public string Summary { get; set; }

                [JsonProperty(PropertyName = "icon")]
                public string Icon { get; set; }

                [JsonProperty(PropertyName = "temperatureHigh")]
                public double TemperatureHigh { get; set; }

                public string TempHigh
                {
                    get { return Math.Round(TemperatureHigh).ToString() + "°c"; }
                    set { }
                }

                [JsonProperty(PropertyName = "temperatureLow")]
                public double TemperatureLow { get; set; }
            }
        }
    }
}
