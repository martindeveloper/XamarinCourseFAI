using System;
using System.Drawing;

using Foundation;
using UIKit;
using System.Collections.Generic;

namespace TaskDemo
{
	public partial class TaskDemoViewController : UIViewController
	{
		public TaskDemoViewController (IntPtr handle) : base (handle)
		{

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
			
			// Perform any additional setup after loading the view, typically from a nib.

			List<string> itemsFromStorage = new List<string> ();
			itemsFromStorage.Add ("Ahoj");
			itemsFromStorage.Add ("<3 Xamarin");

			TasksTableView.Source = new TasksTableViewSource (itemsFromStorage);

			TaskInputField.ShouldReturn += (UITextField textField) => {
				textField.ResignFirstResponder();

				return true;
			};
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

		partial void OnBtnSubmitEventHandler (UIButton sender)
		{
			TasksTableViewSource source = (TasksTableViewSource)TasksTableView.Source;
			source.AddItem(TaskInputField.Text);
			TasksTableView.ReloadData();

			TaskInputField.Text = "";
			TaskInputField.ResignFirstResponder();
		}
	}
}

