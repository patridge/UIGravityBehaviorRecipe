using System.Drawing;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

namespace UIKitPlayground.UIGravityBehaviorRecipe {
    public class ChangingGravityViewController : UIViewController {
        UIDynamicAnimator animator;
        UIGravityBehavior gravity;
        readonly Queue<UIView> items = new Queue<UIView>();
        static readonly SizeF sizeInitial = new SizeF(25f, 25f);

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            animator = new UIDynamicAnimator(View);
            gravity = new UIGravityBehavior();
            animator.AddBehavior(gravity);

            // Tap to add new item.
            View.AddGestureRecognizer(new UITapGestureRecognizer((gesture) => {
                PointF tapLocation = gesture.LocationInView(View);
                var item = new UIView(new RectangleF(PointF.Empty, sizeInitial)) {
                    BackgroundColor = ColorHelpers.GetRandomColor(),
                    Center = tapLocation,
                };
                items.Enqueue(item);
                View.Add(item);
                gravity.AddItem(item);

                // Clean up old items so things don't get too leaky.
                if (items.Count > 20) {
                    var oldItem = items.Dequeue();
                    oldItem.RemoveFromSuperview();
                    gravity.RemoveItem(oldItem);
                    oldItem.Dispose();
                }
            }));

            // Swipe to change gravity direction.
            View.AddGestureRecognizer(new UISwipeGestureRecognizer((gesture) => {
                gravity.GravityDirection = new CGVector(1, 0);
            }) { Direction = UISwipeGestureRecognizerDirection.Right, });
            View.AddGestureRecognizer(new UISwipeGestureRecognizer((gesture) => {
                gravity.GravityDirection = new CGVector(-1, 0);
            }) { Direction = UISwipeGestureRecognizerDirection.Left, });
            View.AddGestureRecognizer(new UISwipeGestureRecognizer((gesture) => {
                gravity.GravityDirection = new CGVector(0, -1);
            }) { Direction = UISwipeGestureRecognizerDirection.Up, });
            View.AddGestureRecognizer(new UISwipeGestureRecognizer((gesture) => {
                gravity.GravityDirection = new CGVector(0, 1);
            }) { Direction = UISwipeGestureRecognizerDirection.Down, });
        }

        public override bool PrefersStatusBarHidden() {
            return true;
        }
    }
}