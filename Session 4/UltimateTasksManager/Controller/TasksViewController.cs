using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using UltimateTasksManager.Model;
using UltimateTasksManager.View;

namespace UltimateTasksManager.Controller
{
	public partial class TasksViewController : UIViewController
	{
		private TasksTableViewSource TableSource;
		private TasksCollection Items;

		public TasksViewController (IntPtr handle) : base (handle)
		{
			//TODO: Remove this dummy data
			Items = TasksCollection.GetInstance ();

			Random random = new Random ();

			for (int i = 0; i < 5; i++) {
				TaskEntity item = new TaskEntity () {
					Id = (i + 1),
					Title = "Task #" + i,
					DueDate = DateTime.Now,
					State = (i % 2 == 0) ? true : false,
					Priority = (TaskPriority)random.Next (1, 3)
				};

				Items.Add (item);
			}

			TableSource = new TasksTableViewSource (Items);
		}

		partial void ItemStateChanged (UISwitch sender)
		{
			TaskCellView parentCell = (TaskCellView)sender.Superview.Superview;
			//NSIndexPath indexPath = TasksTableView.IndexPathForCell(parentCell);
			//TaskEntity entity = parentCell.Entity;

			//TODO: Update logic here
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

			TasksTableView.SetSource(TableSource);
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

