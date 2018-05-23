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
        //WEATHER PAGE
        [JsonProperty(PropertyName = "time")]
        public long Time { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "temperature")]
        public double Temperature { get; set; }

        public string Temp
        {
            get { return Math.Round(Temperature).ToString() + "°c"; }
        }

        //DETAILS PAGE

        [JsonProperty(PropertyName = "apparentTemperature")]
        public double ApparentTemperature { get; set; }

        public string ApparentTemp
        {
            get { return Math.Round(ApparentTemperature).ToString() + "°c"; }
        }

        [JsonProperty(PropertyName = "humidity")]
        public double Humidity { get; set; }

        public string Hum
        {
            get { return (Humidity * 100).ToString() + "%"; }
        }

        [JsonProperty(PropertyName = "uvIndex")]
        public double UvIndex { get; set; }

        [JsonProperty(PropertyName = "visibility")]
        public double Visibility { get; set; }

        public string Vis
        {
            get { return Math.Round(Visibility).ToString() + "km"; }
        }

        [JsonProperty(PropertyName = "dewPoint")]
        public double DewPoint { get; set; }

        public string Dew
        {
            get { return Math.Round(DewPoint).ToString() + "°c"; }
        }

        [JsonProperty(PropertyName = "pressure")]
        public double Pressure { get; set; }

        public string Press
        {
            get { return Math.Round(Pressure).ToString() + "mb"; }
        }

        /*
        public double temperature
        {
            get { return Math.Round(Temperature); }
        }
        

        public double apparentTemperature { get; set; }
        */
    }
}
