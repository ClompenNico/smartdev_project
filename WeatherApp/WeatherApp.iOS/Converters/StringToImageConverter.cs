using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UIKit;

namespace WeatherApp.iOS.Converters
{
    public class StringToImageConverter : MvxValueConverter<string, UIImage>
    {
        protected override UIImage Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetImage(value);
        }

        private UIImage GetImage(string value)
        {
            /*
            if (value == "partly-cloudy-night")
            {
                return UIImage.FromFile("Images/Currently/partly-cloudy-night.png");
            }
            else
            {
                return UIImage.FromFile("Images/details.png");
            }
            */
            
            switch(value)
            {
                case "clear-day":
                    return UIImage.FromFile("Images/Currently/clear-day.png");
                    break;
                case "clear-night":
                    return UIImage.FromFile("Images/Currently/clear-night.png");
                    break;
                case "cloudy":
                    return UIImage.FromFile("Images/Currently/cloudy.png");
                    break;
                case "fog":
                    return UIImage.FromFile("Images/Currently/fog.png");
                    break;
                case "partly-cloudy-day":
                    return UIImage.FromFile("Images/Currently/partly-cloudy-day.png");
                    break;
                case "partly-cloudy-night":
                    return UIImage.FromFile("Images/Currently/partly-cloudy-night.png");
                    break;
                case "rain":
                    return UIImage.FromFile("Images/Currently/rain.png");
                    break;
                case "sleet":
                    return UIImage.FromFile("Images/Currently/sleet.png");
                    break;
                case "snow":
                    return UIImage.FromFile("Images/Currently/snow.png");
                    break;
                case "wind":
                    return UIImage.FromFile("Images/Currently/wind.png");
                    break;
                default:
                    return UIImage.FromFile("Images/details.png");
                    break;
            }
        }
    }
}
