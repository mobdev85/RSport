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


[assembly: ExportRenderer(typeof(CircleFrame), typeof(CircleFrameRenderer))]
namespace URSpot.iOS.Renderers
{
    public class CircleFrameRenderer : VisualElementRenderer<Frame>
    {
        private readonly Color DefaultColor = Color.White;

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            CreateCircle();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName ||
                e.PropertyName == CircleFrame.BorderColorProperty.PropertyName ||
                e.PropertyName == CircleFrame.BorderThicknessProperty.PropertyName ||
                e.PropertyName == CircleFrame.BackgroundColorProperty.PropertyName)
            {
                CreateCircle();
            }
        }

        private void CreateCircle()
        {
            CGPoint origin = Bounds.Location;
            var min = Math.Min(Element.Width, Element.Height);
            Layer.BackgroundColor = DefaultColor.ToCGColor();
            Layer.CornerRadius = (float)(min / 2.0);
            Layer.MasksToBounds = false;
            Layer.BackgroundColor = ((CircleFrame)Element).BackgroundColor.ToCGColor();
            Layer.BorderColor = ((CircleFrame)Element).BorderColor.ToCGColor();
            Layer.BorderWidth = ((CircleFrame)Element).BorderThickness;
            ClipsToBounds = true;

        }
    }
}
