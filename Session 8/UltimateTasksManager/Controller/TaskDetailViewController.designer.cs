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
	partial class TaskDetailViewController
	{
		[Outlet]
		UIKit.UILabel DescriptionLabel { get; set; }

		[Outlet]
		UIKit.UILabel DueDateLabel { get; set; }

		[Outlet]
		UIKit.UILabel ForecastLabel { get; set; }

		[Outlet]
		UIKit.UILabel TitleLabel { get; set; }

		[Action ("DeleteButtonTapped:")]
		partial void DeleteButtonTapped (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (DescriptionLabel != null) {
				DescriptionLabel.Dispose ();
				DescriptionLabel = null;
			}

			if (DueDateLabel != null) {
				DueDateLabel.Dispose ();
				DueDateLabel = null;
			}

			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}

			if (ForecastLabel != null) {
				ForecastLabel.Dispose ();
				ForecastLabel = null;
			}
		}
	}
}
