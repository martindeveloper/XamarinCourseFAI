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
	[Register ("TasksViewController")]
	partial class TasksViewController
	{
		[Outlet]
		UltimateTasksManager.View.TasksTableView TasksTableView { get; set; }

		[Action ("ItemStateChanged:")]
		partial void ItemStateChanged (UIKit.UISwitch sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (TasksTableView != null) {
				TasksTableView.Dispose ();
				TasksTableView = null;
			}
		}
	}
}
