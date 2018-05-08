using Airbnb.Lottie;
using MvvmCross.Platform.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace WeatherApp.iOS.Converters
{
    public class StringToAnimationConverter : MvxValueConverter<string, LOTComposition>
    {
        /*
        protected override LOTComposition Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetJson(value);
        }

        private LOTComposition GetJson(string value)
        {
            var composition = LottieComposition.Factory.FromJsonAsync(Resources, jsonObject);

            var storedJson = JsonConvert.DeserializeObject(File.ReadAllText("Images/Details/UVIndexAnim.json"));

            LOTComposition composition = storedJson;

            switch (value)
            {
                case "clear-day":
                    return storedJson;
                    break;
            }
        }
        */
    }
}
