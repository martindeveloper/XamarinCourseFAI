// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace UltimateTasksManager.View
{
	partial class TaskCellView
	{
		[Outlet]
		UIKit.UILabel Priority { get; set; }

		[Outlet]
		UIKit.UISwitch State { get; set; }

		[Outlet]
		UIKit.UILabel Title { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Title != null) {
				Title.Dispose ();
				Title = null;
			}

			if (Priority != null) {
				Priority.Dispose ();
				Priority = null;
			}

			if (State != null) {
				State.Dispose ();
				State = null;
			}
		}
	}
}
