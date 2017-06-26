using URSpot.Core.Pages.Common;
using URSpot.iOS.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;
using CoreGraphics;
using UIKit;


[assembly: ExportRenderer(typeof(CircleImage), typeof(CircleImageRenderer))]
namespace URSpot.iOS.Renderers
{
    public class CircleImageRenderer : ImageRenderer //VisualElementRenderer<Image>
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }

        private void CreateCircle()
        {
            try
            {
                double min = Math.Min(Element.Width, Element.Height);
                var cornerRadius = ((CircleImage)Element).BorderRadius;
                Control.Layer.CornerRadius = cornerRadius == 0 ? (float)(min / 2.0) : cornerRadius;
                Control.Layer.MasksToBounds = false;
                Control.Layer.BorderColor = Color.White.ToCGColor();
                Control.Layer.BorderWidth = 3;
                Control.ClipsToBounds = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to create circle image: " + ex);
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            CreateCircle();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName ||
                e.PropertyName == CircleImage.BorderRadiusProperty.PropertyName ||
                e.PropertyName == CircleImage.BorderColorProperty.PropertyName ||
                e.PropertyName == CircleImage.BorderThicknessProperty.PropertyName)
            {
                CreateCircle();
            }
        }
    }
}
