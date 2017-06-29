using URSpot.Core.Pages.Common;
using URSpot.iOS.Renderers;
using CoreAnimation;
using CoreGraphics;
using System;
using System.ComponentModel;
using System.Drawing;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LabelWithImage), typeof(LabelWithImageRenderer))]
namespace URSpot.iOS.Renderers
{
    public class LabelWithImageRenderer : ViewRenderer<LabelWithImage, UIView>
    {
        private Label label;
        private readonly Xamarin.Forms.Color DefaultColor = Xamarin.Forms.Color.White;

        private CALayer background;

        public LabelWithImageRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<LabelWithImage> e)
        {
            base.OnElementChanged(e);
            if (this.Control == null)
            {
                SetNativeControl(new UIView());
                this.SendSubviewToBack(Control);
            }

            if (e.NewElement != null)
            {
                this.UpdateBackground();

                this.label = e.NewElement.Content.FindByName<Label>("PART_Entry");
                if (label != null)
                {
                    DrawBorder(this.background);
                }
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == LabelWithImage.HeightProperty.PropertyName)
            {
                this.UpdateBackground();
                DrawBorder(this.background);
            }
        }
        void DrawBorder(CALayer cALayer)
        {
            //Bottom border
            if (Control.Layer.Sublayers != null)
                Control.Layer.Sublayers[0].RemoveFromSuperLayer();
            Control.Layer.AddSublayer(cALayer);
        }
        private void UpdateBackground()
        {
            this.background = new CALayer
            {
                BorderColor = this.Element.LineColor.ToCGColor(),
                BorderWidth = this.Element.LineWidth,
                Frame = new CGRect(0.0f, this.Element.Height, UIScreen.MainScreen.Bounds.Width, 1.0f),
                MasksToBounds = true
            };
        }
    }

}