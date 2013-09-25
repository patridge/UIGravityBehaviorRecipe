#Xamarin.iOS UIGravityBehavior Recipe

Playing with the new UIKit Dynamics `UIGravityBehavior`. Get a feel for the basic application of gravity with `BasicGravityViewController`.

    UIDynamicAnimator animator;
    public override void ViewDidLoad() {
        base.ViewDidLoad();
        View.BackgroundColor = UIColor.White;
        animator = new UIDynamicAnimator(View);

        var item = new UIView(new RectangleF(new PointF(50f, 0f), new SizeF(50f, 50f))) {
            BackgroundColor = UIColor.Blue,
        };
        View.Add(item);
        UIGravityBehavior gravity = new UIGravityBehavior(item);
        animator.AddBehavior(gravity);
    }

![Basic UIGravityBehavior](https://raw.github.com/patridge/UIGravityBehaviorRecipe/master/Screenshots/BasicUIGravityBehavior.gif)

Then, play around with changing gravity in `ChangingGravityViewController`.

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

![Controlling UIGravityBehavior by swipe](https://raw.github.com/patridge/UIGravityBehaviorRecipe/master/Screenshots/ControllingUIGravityBehavior.gif)