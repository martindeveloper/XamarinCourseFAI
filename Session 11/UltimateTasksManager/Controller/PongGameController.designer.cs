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
	partial class PongGameController
	{
		[Outlet]
		UIKit.UIView BallView { get; set; }

		[Outlet]
		UIKit.UIView PaddleView { get; set; }

		[Action ("ExitButtonTapped:")]
		partial void ExitButtonTapped (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (BallView != null) {
				BallView.Dispose ();
				BallView = null;
			}

			if (PaddleView != null) {
				PaddleView.Dispose ();
				PaddleView = null;
			}
		}
	}
}
