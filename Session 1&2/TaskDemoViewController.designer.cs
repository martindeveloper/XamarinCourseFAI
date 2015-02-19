// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TaskDemo
{
	[Register ("TaskDemoViewController")]
	partial class TaskDemoViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton BtnSubmit { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField TaskInputField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView TasksTableView { get; set; }

		[Action ("OnBtnSubmitEventHandler:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void OnBtnSubmitEventHandler (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (BtnSubmit != null) {
				BtnSubmit.Dispose ();
				BtnSubmit = null;
			}
			if (TaskInputField != null) {
				TaskInputField.Dispose ();
				TaskInputField = null;
			}
			if (TasksTableView != null) {
				TasksTableView.Dispose ();
				TasksTableView = null;
			}
		}
	}
}
