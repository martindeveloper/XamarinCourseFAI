using System;
using UIKit;
using Foundation;

namespace UltimateTasksManager
{
	[Register ("TaskCellView")]
	public partial class TaskCellView : UITableViewCell
	{
		public TaskCellView (IntPtr handle) : base (handle) {}

		public void SetTitle(string title)
		{
			Title.Text = title;
		}

		public void SetPriority(TaskPriority priority)
		{
			switch (priority) {
			case TaskPriority.Low:
				Priority.Text = "!";
				break;
			case TaskPriority.Medium:
				Priority.Text = "!!";
				Priority.TextColor = UIColor.Orange;
				break;
			case TaskPriority.High:
				Priority.Text = "!!!";
				Priority.TextColor = UIColor.Red;
				break;
			}
		}

		public void SetState(bool state)
		{
			State.SetState (state, false);
		}
	}
}

