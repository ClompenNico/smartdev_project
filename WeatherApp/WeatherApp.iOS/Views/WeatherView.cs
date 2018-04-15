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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //string temp =    //.ToString() + "°c"

            MvxFluentBindingDescriptionSet<WeatherView, WeatherViewModel> set = this.CreateBindingSet<WeatherView, WeatherViewModel>();

            set.Bind(lblTemperature).To(vm => vm.Weather.Currently.Temp);
            set.Bind(lblSummary).To(vm => vm.Weather.Currently.Summary);
            set.Bind(lblHourSummary).To(vm => vm.Weather.Minutely.Summary);

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