using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core.Models
{
    public class GlobalVariables
    {
        //Gobale variabelen
        public static bool ToggleDailyValue { get; set; }
        public static double _LONGITUDE { get; set; }
        public static double _LATITUDE { get; set; }
        public static string FileValue { get; set; }
        public static Weather weatherUpdate { get; set; }

        /*
        public static string AlertTitle { get; set; }
        public static string AlertAction { get; set; }
        */

        //Voor de alert body van 
        public static string AlertBody { get; set; }
    }
}
