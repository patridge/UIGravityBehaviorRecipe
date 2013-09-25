using System.Drawing;
using MonoTouch.UIKit;

namespace UIKitPlayground.UIGravityBehaviorRecipe {
    public class BasicGravityViewController : UIViewController {
        UIDynamicAnimator animator;
        UIView item;
        public override void ViewDidLoad() {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            animator = new UIDynamicAnimator(View);

            item = new UIView(new RectangleF(new PointF(50f, 0f), new SizeF(50f, 50f))) {
                BackgroundColor = UIColor.Blue,
            };
            View.Add(item);
            UIGravityBehavior gravity = new UIGravityBehavior(item);
            animator.AddBehavior(gravity);

            // Tap to bring item back.
            View.AddGestureRecognizer(new UITapGestureRecognizer((gesture) => {
                PointF tapLocation = gesture.LocationInView(View);
                // Must remove from gravity first or it will only flash to location
                // then continue animated from where it was.
                gravity.RemoveItem(item);
                item.Center = tapLocation;
                gravity.AddItem(item);
            }));
        }
    }
}