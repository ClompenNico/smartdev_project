using Airbnb.Lottie;
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
    public partial class TabDetailsView : MvxViewController<TabDetailsViewModel>
    {
        LOTAnimationView _uvIndexAnimation;

        public TabDetailsView (IntPtr handle) : base (handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            MvxFluentBindingDescriptionSet<TabDetailsView, TabDetailsViewModel> set = this.CreateBindingSet<TabDetailsView, TabDetailsViewModel>();

            this._uvIndexAnimation = LOTAnimationView.AnimationNamed("UVIndexAnim.json"); //your animation name for the uv sun
            this._uvIndexAnimation.Frame = new CoreGraphics.CGRect(0, 0, 50, 50); //Depending on the dimensions of you animation and cell
            this._uvIndexAnimation.ContentMode = UIViewContentMode.ScaleAspectFill;
            this._uvIndexAnimation.LoopAnimation = true;
            this.imgUvInd.AddSubview(this._uvIndexAnimation);

            //set.Bind(_uvIndexAnimation).For(ani => ani.SceneModel);
                /*
                .To(rev => rev.Weather.Currently.UvIndex)
                .WithConversion<StringToImageConverter>();
                */

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

            this._uvIndexAnimation.Play();

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