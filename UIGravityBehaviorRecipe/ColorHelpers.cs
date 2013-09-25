using System;
using MonoTouch.UIKit;

namespace UIKitPlayground.UIGravityBehaviorRecipe {
    public static class ColorHelpers {
        static readonly Random rand = new Random();
        public static UIColor GetRandomColor() {
            int red = rand.Next(255);
            int green = rand.Next(255);
            int blue = rand.Next(255);
            UIColor color = UIColor.FromRGBA(
                (red / 255.0f),
                (green / 255.0f),
                (blue / 255.0f),
                1f);
            return color;
        }
    }
}