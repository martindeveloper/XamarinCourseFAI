using System;
using Foundation;
using UIKit;
using UltimateTasksManager.Model;

namespace UltimateTasksManager.Controller
{
	[Register ("TaskDetailViewController")]
	partial class TaskDetailViewController : UIViewController
	{
		public TaskEntity SelectedTask { get; set; }

		public TaskDetailViewController (IntPtr ptr) : base (ptr)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			// Set data from item
			if (SelectedTask != null) {
				TitleLabel.Text = SelectedTask.Title;

				if (SelectedTask.State) {
					TitleLabel.TextColor = UIColor.Green;
				}

				DescriptionLabel.Text = SelectedTask.Description;
				DueDateLabel.Text = SelectedTask.DueDate.ToLongDateString ();
				// TODO: Priority
			} else {
				throw new ArgumentException ("You must set SelectedTask property to show detail view!");
			}
		}

		partial void DeleteButtonTapped (NSObject sender)
		{
			string[] buttons = { "Yes" };
			UIAlertView alert = new UIAlertView ("Confirmation", "Are you sure to delete this task?", null, "No", buttons);

			alert.Clicked += (object alertSender, UIButtonEventArgs e) => {
				switch (e.ButtonIndex) {
				case 0:
					// No
					break;
				case 1:
					// Yes
					TasksCollection collection = TasksCollection.GetInstance ();
					collection.Remove (SelectedTask);

					NavigationController.PopViewController (true);
					break;
				}
			};

			alert.Show ();
		}
	}
}

