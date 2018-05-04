using Foundation;
using MvvmCross.Binding.iOS.Views;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace WeatherApp.iOS.TableViewSources
{
    public class WeekTableViewSource : MvxTableViewSource
    {
        public WeekTableViewSource(UITableView tableView) : base(tableView)
        {

        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = (WeekTableCell)tableView.DequeueReusableCell(WeekTableCell.Identifier, indexPath);
            return cell;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 80;
        }
    }
}
