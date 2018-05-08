using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using WeatherApp.Core.ViewModels;
using WeatherApp.iOS.TableViewSources;

namespace WeatherApp.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabWeekTableView : MvxTableViewController<TabWeekTableViewModel>
    {
        public TabWeekTableView (IntPtr handle) : base (handle)
        {
        }

        WeekTableViewSource _weekTableViewSource;

        public override void ViewDidLoad()
        {
            _weekTableViewSource = new WeekTableViewSource(this.TableView);

            base.ViewDidLoad();

            this.TableView.Source = _weekTableViewSource;
            this.TableView.ReloadData();

            MvxFluentBindingDescriptionSet<TabWeekTableView, TabWeekTableViewModel> set = new MvxFluentBindingDescriptionSet<TabWeekTableView, TabWeekTableViewModel>(this);

            set.Bind(_weekTableViewSource).To(vm => vm.DailyDataList);

            /*
            set.Bind(_weekTableViewSource)
                .For(src => src.SelectionChangedCommand)
                .To(vm => vm.NavigateToDayCommand);
            */
            
            set.Apply();
        }
    }
}