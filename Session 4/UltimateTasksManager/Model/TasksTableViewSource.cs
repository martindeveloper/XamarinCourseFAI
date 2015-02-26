using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using UltimateTasksManager.Model;
using UltimateTasksManager.View;

namespace UltimateTasksManager.Model
{
	public class TasksTableViewSource : UITableViewSource
	{
		private TasksCollection Items;
		private const string CellIdentifier = "ItemCell";

		public TasksTableViewSource(TasksCollection items)
		{
			Items = items;
		}

		#region implemented abstract members of UITableViewSource
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			TaskCellView cell = (TaskCellView)tableView.DequeueReusableCell (CellIdentifier);
			//NOTE: From iOS 5 with Storyboards and cell prototype we will never get nil

			TaskEntity item = Items [indexPath.Row];
			cell.Entity = item;

			return cell;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return Items.Count;
		}
		#endregion
	}
}

