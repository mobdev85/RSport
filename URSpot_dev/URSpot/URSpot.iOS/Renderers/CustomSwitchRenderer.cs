using URSpot.Core.Pages.Common;
using URSpot.iOS.Renderers;
using CoreAnimation;
using CoreGraphics;
using System;
using System.Drawing;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
namespace URSpot.iOS.Renderers
{
    public class CustomSwitchRenderer : SwitchRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Change the UISwitch Tint Color
                Control.OnTintColor = new UIColor(red: 0.67f, green: 0.50f, blue: 1.00f, alpha: 1.0f);
            }
        }
    }
}
