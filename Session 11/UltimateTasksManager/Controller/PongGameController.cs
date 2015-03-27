using System;
using Foundation;
using UIKit;
using CoreGraphics;

namespace UltimateTasksManager.Controller
{
	[Register("PongGameController")]
	partial class PongGameController : UIViewController
	{
		private UIDynamicAnimator Animator;
		private UIPushBehavior BallPusher;
		private UICollisionBehavior Colliders;
		private UIAttachmentBehavior PaddleAttacher;

		public PongGameController (IntPtr ptr) : base (ptr)
		{
		}

		private void CreateAnimator ()
		{
			Animator = new UIDynamicAnimator (View);
		}

		private void CreateBallPusher()
		{
			IUIDynamicItem[] items = { BallView };

			// Add force which will push ball down
			BallPusher = new UIPushBehavior (items, UIPushBehaviorMode.Instantaneous);
			BallPusher.PushDirection = new CGVector (0.1f, 0.3f);
			BallPusher.Active = true;

			Animator.AddBehavior (BallPusher);
		}

		private void CreateColliders()
		{
			IUIDynamicItem[] colliderItems = { BallView, PaddleView };

			Colliders = new UICollisionBehavior(colliderItems);

			CollidersDelegate collisionDelegate = new CollidersDelegate () { ViewFrameHeight = View.Frame.Height };
			collisionDelegate.OnCollisionWithBottom = () => {
				DismissModalViewController (true);
			};

			Colliders.CollisionDelegate = collisionDelegate;
			Colliders.CollisionMode = UICollisionBehaviorMode.Everything;
			Colliders.TranslatesReferenceBoundsIntoBoundary = true;

			Animator.AddBehavior (Colliders);
		}

		private void RemoveRotationForView (UIView target)
		{
			UIDynamicItemBehavior properties = new UIDynamicItemBehavior(new []{ target });
			properties.AllowsRotation = false;

			Animator.AddBehavior (properties);
		}

		private void SetDensityForView (UIView target, nfloat density)
		{
			UIDynamicItemBehavior properties = new UIDynamicItemBehavior(new []{ target });
			properties.Density = density;

			Animator.AddBehavior (properties);
		}

		private void InitializeBall ()
		{
			UIDynamicItemBehavior properties = new UIDynamicItemBehavior(new []{ BallView });

			// Disallow rotation
			properties.AllowsRotation = false; 

			// Physics attributes
			properties.Elasticity = 1.0f;
			properties.Friction = 0.0f;
			properties.Resistance = 0.0f;

			Animator.AddBehavior (properties);
		}

		private void InitializePaddle ()
		{
			UIDynamicItemBehavior properties = new UIDynamicItemBehavior(new []{ PaddleView });

			// Disallow rotation
			properties.AllowsRotation = false;

			// Paddle will be heavy
			properties.Density = 1000.0f;

			Animator.AddBehavior (properties);

			// Create attacher (
			PaddleAttacher = new UIAttachmentBehavior (PaddleView, new CGPoint(PaddleView.Frame.GetMidX(), PaddleView.Frame.GetMidY()));
			Animator.AddBehavior (PaddleAttacher);

			// Create gesture recognizer
			UITapGestureRecognizer paddleGestureRecognizer = new UITapGestureRecognizer( (UITapGestureRecognizer recognizer) => {
				CGPoint tapLocation = recognizer.LocationInView(View);

				// We will modify only X coordinate
				PaddleAttacher.AnchorPoint = new CGPoint(tapLocation.X, PaddleAttacher.AnchorPoint.Y);
			});

			View.AddGestureRecognizer (paddleGestureRecognizer);
		}

		public override void ViewDidAppear (bool animated)
		{
			CreateAnimator ();
			CreateBallPusher ();
			CreateColliders ();

			InitializeBall ();
			InitializePaddle ();

			base.ViewDidAppear (animated);
		}

		partial void ExitButtonTapped (UIKit.UIButton sender)
		{
			DismissModalViewController (true);
		}
	}

	public class CollidersDelegate : UICollisionBehaviorDelegate {
		public nfloat ViewFrameHeight = 0.0f;
		public nfloat Tolerance = 2.0f;

		public Action OnCollisionWithBottom;

		public override void BeganBoundaryContact (UICollisionBehavior behavior, IUIDynamicItem dynamicItem, NSObject boundaryIdentifier, CGPoint atPoint)
		{
			if (ViewFrameHeight != 0 && (atPoint.Y + Tolerance) > ViewFrameHeight) {
				// Screen bottom
				if (OnCollisionWithBottom != null) {
					OnCollisionWithBottom ();
				}
			}
		}
	}
}

