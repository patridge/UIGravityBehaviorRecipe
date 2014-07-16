using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Diagnostics;

namespace UIKitPlayground.UIGravityBehaviorRecipe {
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate {
        UIWindow window;
        UIViewController viewController;
        public override bool FinishedLaunching(UIApplication app, NSDictionary options) {
            UIApplication.SharedApplication.SetStatusBarHidden(true, UIStatusBarAnimation.Slide);
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            viewController = new ChangingGravityViewController();
            window.RootViewController = viewController;
            window.MakeKeyAndVisible();

            return true;
        }
    }
    public class Application {
        static void Main(string[] args) {
            try {
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (Exception ex) {
                Debug.WriteLine("Top-level exception: {0}", ex);
            }
        }
    }
}