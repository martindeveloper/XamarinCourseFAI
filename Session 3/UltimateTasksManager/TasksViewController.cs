using System;
using System.Drawing;

using Foundation;
using UIKit;
using System.Collections.Generic;

namespace UltimateTasksManager
{
	public partial class TasksViewController : UIViewController
	{
		private TasksTableViewSource TableSource;

		public TasksViewController (IntPtr handle) : base (handle)
		{
			//TODO: Remove this dummy data
			List<TaskEntity> items = new List<TaskEntity> ();
			Random random = new Random ();

			for (int i = 0; i < 100; i++) {
				TaskEntity item = new TaskEntity () {
					Id = (i + 1),
					Title = "Task #" + i,
					DueDate = DateTime.Now,
					State = (i % 2 == 0) ? true : false,
					Priority = (TaskPriority)random.Next (1, 3)
				};

				items.Add (item);
			}

			TableSource = new TasksTableViewSource (items);
		}

		partial void ItemStateChanged (UISwitch sender)
		{
			TaskCellView parentCell = (TaskCellView)sender.Superview.Superview;
			NSIndexPath indexPath = TasksTableView.IndexPathForCell(parentCell);

			UIAlertView alert = new UIAlertView("Task info", TableSource.GetTaskAtIndex(indexPath.Row).Title, null, "Dismiss", null);
			alert.Show();
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			TasksTableView.Source = TableSource;
			TasksTableView.ReloadData ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion
	}
}

