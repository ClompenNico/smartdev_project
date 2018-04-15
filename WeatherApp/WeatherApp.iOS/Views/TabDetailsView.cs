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
    }
}