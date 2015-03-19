using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using UltimateTasksManager.Model;
using UltimateTasksManager.View;
using System.Linq;

namespace UltimateTasksManager.Controller
{
	public partial class TasksViewController : UIViewController
	{
		private TasksTableViewSource TableSource;
		private TasksCollection Items;

		private const string DetailViewSegueIdentifier = "TaskDetailViewControllerSegue";

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

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == DetailViewSegueIdentifier) {
				TaskDetailViewController detailView = segue.DestinationViewController as TaskDetailViewController;

				if (detailView != null) {
					NSIndexPath rowPath = TasksTableView.IndexPathForSelectedRow; // Get selected row

					try {
						TaskEntity task = Items [rowPath.Row]; // Get task from Model

						detailView.SelectedTask = task;
					} catch (KeyNotFoundException ex) {
						// Log error and show user message, BUT this error cant happen!
						// User cant tap item which isnt in model
						Console.WriteLine(ex.Message);
					}
				}
			}

			base.PrepareForSegue (segue, sender);
		}

		partial void ItemStateChanged (UISwitch sender)
		{
			TaskCellView parentCell = (TaskCellView)sender.Superview.Superview;
			TaskEntity entity = parentCell.Entity;

			//TODO: Use model facade

			entity.State = sender.On;
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

			TasksTableView.SetSource (TableSource);
			TasksTableView.ReloadData ();

			// Row tap handler
			TableSource.OnRowSelectedEvent += (NSIndexPath indexPath, TasksCollection items) => {
				PerformSegue (DetailViewSegueIdentifier, this);
			};

			// Search handler
			SearchBar.TextChanged += SearchHandler;
		}

		private void SearchHandler(object sender, EventArgs e)
		{
			string query = SearchBar.Text;

			// TODO: W8 for new model structure
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

