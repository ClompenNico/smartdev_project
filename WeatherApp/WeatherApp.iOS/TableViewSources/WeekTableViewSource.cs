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

        //Zorgt voor het beheer van de tableview waaraan hij gekoppeld is
        //Responsible voor het weergeven van cellen, reorderen van rijen en verwijderen van rijen
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
