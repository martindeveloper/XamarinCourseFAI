using System;
using UIKit;
using Foundation;
using CoreAnimation;

namespace UltimateTasksManager
{
	[Register("DetailViewSegue")]
	public class DetailViewSegue : UIStoryboardSegue
	{
		public DetailViewSegue(IntPtr ptr) : base(ptr)
		{}

		public override void Perform ()
		{
			CATransition transition = new CATransition ();
			transition.Duration = 2.0f;
			transition.TimingFunction = CAMediaTimingFunction.FromName (CAMediaTimingFunction.EaseInEaseOut);
			transition.Type = CATransition.TransitionReveal;
			transition.Subtype = CATransition.TransitionFromTop;

			SourceViewController.NavigationController.View.Layer.AddAnimation (transition, null);
			SourceViewController.NavigationController.PushViewController (DestinationViewController, false);
		}
	}
}

