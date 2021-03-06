﻿using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using WeatherApp.Core.ViewModels;

namespace WeatherApp.iOS
{
    public partial class WeatherTabsView : MvxTabBarViewController<WeatherTabsViewModel>
    {
        /*
        public WeatherTabsView (IntPtr handle) : base (handle)
        {
        }
        */

        //bool voor constructed
        private bool _constructed;

        public WeatherTabsView()
        {
            //Als constructed, dan viewdidload uitvoeren
            _constructed = true;
            ViewDidLoad();
        }

        public override void ViewDidLoad()
        {
            if (!_constructed) return;

            base.ViewDidLoad();

            NavigationItem.RightBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Compose);

            MvxFluentBindingDescriptionSet<WeatherTabsView, WeatherTabsViewModel> set = this.CreateBindingSet<WeatherTabsView, WeatherTabsViewModel>();

            //Button navigatie binden
            set.Bind(NavigationItem.RightBarButtonItem).To(vm => vm.NotificationsCommand);
            set.Apply();

            //tabs aanmaken
            CreateTabs();
        }

        private void CreateTabs()
        {
            //voeg viewcontrollers toe voor elk tabblad en bewaar
            var viewControllers = new UIViewController[]
            {
                //Iedere tab met correcte afbeelding weergeven
                CreateSingleTab("Weather", "Images/weather.png", ViewModel.WeatherVM),
                CreateSingleTab("Details", "Images/details.png", ViewModel.TabDetailsVM),
                CreateSingleTab("Week", "Images/week.png", ViewModel.TabWeekVM),
            };

            ViewControllers = viewControllers;

            //stel de eerste tab in als geselecteerd
            SelectedViewController = ViewControllers[0];

            //pas titel aan bij het selecteren van een tabblad
            NavigationItem.Title = SelectedViewController.Title;

            ViewControllerSelected += (o, e) =>
            {
                NavigationItem.Title = TabBar.SelectedItem.Title;
            };
        }

        private UIViewController CreateSingleTab(string tabName, string imgPath, MvxViewModel tabViewModel)
        {
            //viewcontroller aanmaken adhv viewmodel
            var viewController =
                this.CreateViewControllerFor(tabViewModel) as UIViewController;
            tabViewModel.Start();

            //titel instellen op naam tabblad
            viewController.Title = tabName;
            viewController.TabBarItem = new UITabBarItem() { Title = tabName, Image = UIImage.FromFile(imgPath) };

            return viewController;
        }
    }
}