using System;
using UIKit;
using Foundation;
using UltimateTasksManager.Model;

namespace UltimateTasksManager.Controller
{
	[Register("AddTaskTableViewController")]
	public partial class AddTaskTableViewController : UITableViewController
	{
		public TasksRepository TasksModel;

		public AddTaskTableViewController (IntPtr ptr) : base(ptr)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			TitleTextField.ShouldReturn += TextFieldShouldReturnHandler;
			DescriptionTextField.ShouldReturn += TextFieldShouldReturnHandler;
		}

		private bool TextFieldShouldReturnHandler(UITextField textField)
		{
			textField.ResignFirstResponder ();

			return true;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			PriorityPicker.Model = new PriorityPickerModel ();

			if (TasksModel == null) {
				throw new ArgumentNullException ("Controller needs TasksRepository instance to be set!");
			}
		}

		partial void OnSaveButtonTap (UIKit.UIBarButtonItem sender)
		{
			//TODO: Create validators and move logic to model layer
			string title = TitleTextField.Text;
			string description = DescriptionTextField.Text;
			NSDate dueDate = DueDatePicker.Date;
			TaskPriority priority = (TaskPriority)((int)PriorityPicker.SelectedRowInComponent(0) + 1);

			UIAlertView alert;

			if(String.IsNullOrEmpty(title))
			{
				alert = new UIAlertView("Houston, we have a problem", "You missed the title field, go ahead and fill it.", null, "Dismiss", null);
				alert.Show();
			}
			else
			{
				// Show success alert and save to collection
				//TODO: Use database abstraction here

				DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
				reference = reference.AddSeconds(dueDate.SecondsSinceReferenceDate);

				TaskEntity task = new TaskEntity() {
					State = false,
					Title = title,
					Description = description,
					DueDate = reference,
					Priority = priority
				};

				TasksModel.Add(task);

				alert = new UIAlertView("Great!", "Nice job, you added new task!", null, "Dismiss", null);
				alert.Show();

				NavigationController.PopViewController(true);
			}
		}
	}
}

