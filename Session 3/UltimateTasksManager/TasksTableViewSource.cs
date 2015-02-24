using System;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace UltimateTasksManager
{
	public class TasksTableViewSource : UITableViewSource
	{
		private List<TaskEntity> Items; //TODO: Use DataSource which will read items from SQLite
		private const string CellIdentifier = "ItemCell";

		public TasksTableViewSource()
		{
			Items = new List<TaskEntity> ();
		}

		public TasksTableViewSource(List<TaskEntity> items) : this()
		{
			Items = items;
		}

		public void AddTask(TaskEntity item)
		{
			Items.Add (item);
		}

		public TaskEntity GetTaskAtIndex(int index)
		{
			return Items [index];
		}

		#region implemented abstract members of UITableViewSource
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			TaskCellView cell = (TaskCellView)tableView.DequeueReusableCell (CellIdentifier);
			//NOTE: From iOS 5 with Storyboards and cell prototype we will never get nil

			TaskEntity item = Items [indexPath.Row];

			cell.SetTitle (item.Title);
			cell.SetPriority (item.Priority);
			cell.SetState (item.State);

			return cell;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return Items.Count;
		}
		#endregion
	}
}

