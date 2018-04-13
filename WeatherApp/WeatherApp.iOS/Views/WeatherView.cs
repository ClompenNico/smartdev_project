using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using WeatherApp.Core.ViewModels;

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

            MvxFluentBindingDescriptionSet<WeatherView, WeatherViewModel> set = this.CreateBindingSet<WeatherView, WeatherViewModel>();

            set.Bind(lblTemperature).To(vm => vm.Weather.Currently.Temperature);
            set.Bind(lblSummary).To(vm => vm.Weather.Currently.Summary);
            set.Bind(lblHourSummary).To(vm => vm.Weather.Minutely.Summary);

            set.Bind(lblLatitude).To(vm => vm.Weather.Latitude);
            set.Bind(lblLongitude).To(vm => vm.Weather.Longitude);
            //set.Bind(imgBackground.Image = UIImage.FromFile("Images/Sunrise.png"));

            set.Apply();
        }
    }
}