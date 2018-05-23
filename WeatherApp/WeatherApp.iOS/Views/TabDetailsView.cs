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
        //Alle verschillende animaties declareren
        LOTAnimationView _uvIndexAnimation;
        LOTAnimationView _pressureAnimation;
        LOTAnimationView _humidityAnimation;
        LOTAnimationView _visibilityAnimation;
        LOTAnimationView _dewpointAnimation;
        LOTAnimationView _apparenttempAnimation;

        public TabDetailsView (IntPtr handle) : base (handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            MvxFluentBindingDescriptionSet<TabDetailsView, TabDetailsViewModel> set = this.CreateBindingSet<TabDetailsView, TabDetailsViewModel>();

            //ANIMATIES OPVRAGEN, GROTE INSTELLEN, SCALEN, LOOP & BINDEN MET HUN IMAGE
            this._uvIndexAnimation = LOTAnimationView.AnimationNamed("UVIndexAnim.json"); //your animation name for the uv sun
            this._uvIndexAnimation.Frame = new CoreGraphics.CGRect(0, 0, 50, 50); //Depending on the dimensions of you animation and cell
            this._uvIndexAnimation.ContentMode = UIViewContentMode.ScaleAspectFill;
            this.imgUvInd.AddSubview(this._uvIndexAnimation);

            this._pressureAnimation = LOTAnimationView.AnimationNamed("Pressure.json");
            this._pressureAnimation.Frame = new CoreGraphics.CGRect(0, 0, 50, 50); //Depending on the dimensions of you animation and cell
            this._pressureAnimation.ContentMode = UIViewContentMode.ScaleAspectFill;
            this._pressureAnimation.LoopAnimation = true;
            this.imgPress.AddSubview(this._pressureAnimation);

            this._humidityAnimation = LOTAnimationView.AnimationNamed("Humidity.json");
            this._humidityAnimation.Frame = new CoreGraphics.CGRect(0, 0, 50, 50); //Depending on the dimensions of you animation and cell
            this._humidityAnimation.ContentMode = UIViewContentMode.ScaleAspectFill;
            this.imgHum.AddSubview(this._humidityAnimation);

            this._visibilityAnimation = LOTAnimationView.AnimationNamed("Visibility.json");
            this._visibilityAnimation.Frame = new CoreGraphics.CGRect(0, 0, 50, 50); //Depending on the dimensions of you animation and cell
            this._visibilityAnimation.ContentMode = UIViewContentMode.ScaleAspectFill;
            this._visibilityAnimation.LoopAnimation = true;
            this.imgVis.AddSubview(this._visibilityAnimation);

            this._dewpointAnimation = LOTAnimationView.AnimationNamed("dewing.json");
            this._dewpointAnimation.Frame = new CoreGraphics.CGRect(0, 0, 50, 50); //Depending on the dimensions of you animation and cell
            this._dewpointAnimation.ContentMode = UIViewContentMode.ScaleAspectFill;
            this.imgDew.AddSubview(this._dewpointAnimation);

            this._apparenttempAnimation = LOTAnimationView.AnimationNamed("apparenttemp.json");
            this._apparenttempAnimation.Frame = new CoreGraphics.CGRect(0, 0, 50, 50); //Depending on the dimensions of you animation and cell
            this._apparenttempAnimation.ContentMode = UIViewContentMode.ScaleAspectFill;
            this._apparenttempAnimation.LoopAnimation = true;
            this.imgApparentTemp.AddSubview(this._apparenttempAnimation);

            //set.Bind(_uvIndexAnimation).For(ani => ani.SceneModel);
            /*
            .To(rev => rev.Weather.Currently.UvIndex)
            .WithConversion<StringToImageConverter>();
            */

            //Alle details binden met de waarden
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
            //Huidige tijd opvragen voor background
            int currentTime = DateTime.Now.Hour;

            base.ViewWillAppear(animated);

            //ANIMATIES STARTEN
            this._uvIndexAnimation.Play();
            this._pressureAnimation.Play();
            this._humidityAnimation.Play();
            this._visibilityAnimation.Play();
            this._dewpointAnimation.Play();
            this._apparenttempAnimation.Play();

            //If else statement voor background op basis van uur
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