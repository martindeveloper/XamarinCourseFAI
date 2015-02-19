using System;
using UIKit;
using System.Collections.Generic;
using Foundation;

namespace TaskDemo
{
	public class TasksTableViewSource : UITableViewSource
	{
		private List<string> TableItems;
		private NSString CellIdentifier = new NSString ("TasksTableCell");

		public TasksTableViewSource (List<string> items)
		{
			TableItems = items;
		}

		public void AddItem(string task)
		{
			TableItems.Add (task);
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return TableItems.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (CellIdentifier);

			if (cell == null)
			{
				cell = new UITableViewCell (UITableViewCellStyle.Default, CellIdentifier);
			}

			cell.TextLabel.Text = TableItems[indexPath.Row];

			return cell;
		}
	}
}

