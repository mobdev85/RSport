using URSpot.Core.Pages.Common;
using URSpot.iOS.Renderers;
using CoreAnimation;
using CoreGraphics;
using System;
using System.Drawing;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using URSpot.Core.Effects;
using URSpot.iOS.Effects;
using System.ComponentModel;

[assembly: ResolutionGroupName("URSpot")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace URSpot.iOS.Effects
{
    public class LabelShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                UpdateRadius();
                UpdateColor();
                UpdateOffset();
                Control.Layer.ShadowOpacity = 1.0f;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }

        void UpdateRadius()
        {
            Control.Layer.CornerRadius = (nfloat)ShadowEffect.GetRadius(Element);
        }

        void UpdateColor()
        {
            Control.Layer.ShadowColor = ShadowEffect.GetColor(Element).ToCGColor();
        }

        void UpdateOffset()
        {
            Control.Layer.ShadowOffset = new CGSize(
                (double)ShadowEffect.GetDistanceX(Element),
                (double)ShadowEffect.GetDistanceY(Element));
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == ShadowEffect.RadiusProperty.PropertyName)
            {
                UpdateRadius();
            }
            else if (args.PropertyName == ShadowEffect.ColorProperty.PropertyName)
            {
                UpdateColor();
            }
            else if (args.PropertyName == ShadowEffect.DistanceXProperty.PropertyName ||
                     args.PropertyName == ShadowEffect.DistanceYProperty.PropertyName)
            {
                UpdateOffset();
            }
        }
    }
}
