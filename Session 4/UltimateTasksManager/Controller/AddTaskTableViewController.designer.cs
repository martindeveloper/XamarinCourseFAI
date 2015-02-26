// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace UltimateTasksManager.Controller
{
	partial class AddTaskTableViewController
	{
		[Outlet]
		UIKit.UITextField DescriptionTextField { get; set; }

		[Outlet]
		UIKit.UIDatePicker DueDatePicker { get; set; }

		[Outlet]
		UIKit.UIPickerView PriorityPicker { get; set; }

		[Outlet]
		UIKit.UITextField TitleTextField { get; set; }

		[Action ("OnSaveButtonTap:")]
		partial void OnSaveButtonTap (UIKit.UIBarButtonItem sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (TitleTextField != null) {
				TitleTextField.Dispose ();
				TitleTextField = null;
			}

			if (DescriptionTextField != null) {
				DescriptionTextField.Dispose ();
				DescriptionTextField = null;
			}

			if (DueDatePicker != null) {
				DueDatePicker.Dispose ();
				DueDatePicker = null;
			}

			if (PriorityPicker != null) {
				PriorityPicker.Dispose ();
				PriorityPicker = null;
			}
		}
	}
}
