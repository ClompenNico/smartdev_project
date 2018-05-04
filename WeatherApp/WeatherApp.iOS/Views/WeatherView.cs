using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using WeatherApp.Core.ViewModels;
using WeatherApp.iOS.Converters;

namespace WeatherApp.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class WeatherView : MvxViewController<WeatherViewModel>
    {
        public WeatherView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            int currentTime = DateTime.Now.Hour;

            base.ViewWillAppear(animated);

            //string locatie = "Day";

            //LoadBackground(locatie);

            if (currentTime <= 6 || currentTime >= 21)
            {
                string locatie = "Night";
                LoadBackground(locatie);
            }
            else if (currentTime <= 9 || currentTime >= 18 && currentTime <= 21)
            {
                string locatie = "Sunrise";
                LoadBackground(locatie);
            }
            else if (currentTime <= 18)
            {
                string locatie = "Day";
                LoadBackground(locatie);
            }
            else
            {
                string locatie = "Day";
                Console.WriteLine("Dikke rip");
                LoadBackground(locatie);
            }

            //sunrisecolor
            //ae6f25
            //1b2936


        }

        public void LoadBackground(string locatie)
        {
            if (UIScreen.MainScreen.Bounds.Height <= 568)
                this.View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Backgrounds/" + locatie + "568.png"));
            else if (UIScreen.MainScreen.Bounds.Height <= 671)
                this.View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Backgrounds/" + locatie + "667.png"));
            else if (UIScreen.MainScreen.Bounds.Height <= 740)
                this.View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Backgrounds/" + locatie + "736.png"));
            else if (UIScreen.MainScreen.Bounds.Height <= 816)
                this.View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Backgrounds/" + locatie + "812.png"));
            else
                this.View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Backgrounds/" + locatie + "Default.png"));
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //string temp =    //.ToString() + "°c"

            MvxFluentBindingDescriptionSet<WeatherView, WeatherViewModel> set = this.CreateBindingSet<WeatherView, WeatherViewModel>();

            set.Bind(lblTemperature).To(vm => vm.Weather.Currently.Temp);
            set.Bind(lblSummary).To(vm => vm.Weather.Currently.Summary);
            set.Bind(lblHourSummary).To(vm => vm.Weather._Hourly.Summary);

            set.Bind(lblLatitude).To(vm => vm.Weather.Latitude);
            set.Bind(lblLongitude).To(vm => vm.Weather.Longitude);

            set.Bind(imgIcon)
                .For(img => img.Image)
                .To(vm => vm.Weather.Currently.Icon)
                .WithConversion<StringToImageConverter>();        

            //set.Bind(imgBackground.Image = UIImage.FromFile("Images/Sunrise.png"));

            set.Apply();
        }
    }
}