using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using WeatherApp.Core.ViewModels;

namespace WeatherApp.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabDetailsView : MvxViewController<TabDetailsViewModel>
    {
        public TabDetailsView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            MvxFluentBindingDescriptionSet<TabDetailsView, TabDetailsViewModel> set = this.CreateBindingSet<TabDetailsView, TabDetailsViewModel>();

            set.Bind(lblApparentTemp).To(vm => vm.Weather.Currently.ApparentTemp);
            set.Bind(lblHum).To(vm => vm.Weather.Currently.Hum);
            set.Bind(lblUv).To(vm => vm.Weather.Currently.UvIndex);
            set.Bind(lblVis).To(vm => vm.Weather.Currently.Vis);
            set.Bind(lblDew).To(vm => vm.Weather.Currently.Dew);
            set.Bind(lblPress).To(vm => vm.Weather.Currently.Press);

            set.Apply();
        }

        public override void ViewWillAppear(bool animated)
        {
            int currentTime = DateTime.Now.Hour;

            base.ViewWillAppear(animated);

            if (currentTime <= 6 || currentTime >= 21)
            {
                this.View.BackgroundColor = UIColor.FromRGB(27, 41, 54);
            }
            else if (currentTime <= 9 || currentTime >= 18 && currentTime <= 21)
            {
                this.View.BackgroundColor = UIColor.FromRGB(174, 111, 37);
            }
            else if (currentTime <= 18)
            {
                this.View.BackgroundColor = UIColor.FromRGB(49, 89, 94);
            }
            else
            {
                this.View.BackgroundColor = UIColor.FromRGB(49, 89, 94);
            }
        }
    }
}