using URSpot.Core.Pages.Common;
using URSpot.iOS.Renderers;
using CoreAnimation;
using CoreGraphics;
using System;
using System.Drawing;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TextBox), typeof(TextBoxRenderer))]
namespace URSpot.iOS.Renderers
{
    public class TextBoxRenderer : ViewRenderer<TextBox, UIView>
    {
        private Entry entry;
        private readonly Xamarin.Forms.Color DefaultColor = Xamarin.Forms.Color.White;

        private CALayer focusedBackground;
        private CALayer unFocusedBackground;

        public TextBoxRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<TextBox> e)
        {
            base.OnElementChanged(e);
            if (this.Control == null)
            {
                SetNativeControl(new UIView());
                this.SendSubviewToBack(Control);
            }

            if (e.NewElement != null)
            {
                this.UpdateFocusedBackground();
                this.UpdateUnFocusedBackground();

                this.entry = e.NewElement.Content.FindByName<Entry>("PART_Entry");
                if (entry != null)
                {
                    entry.Effects.Add(new NoBackgroundEntry());
                    DrawBorder(this.unFocusedBackground);
                    entry.Unfocused += Entry_Unfocused;
                    entry.Focused += Entry_Focused;
                }
            }
        }
        void DrawBorder(CALayer cALayer)
        {
            //Bottom border
            if (Control != null)
                Control.Layer.AddSublayer(cALayer);
        }
        private void UpdateUnFocusedBackground()
        {
            this.unFocusedBackground = new CALayer
            {
                BorderColor = this.Element.LineColor.ToCGColor(),
                BorderWidth = this.Element.LineWidth,
                Frame = new CGRect(0.0f, 30, UIScreen.MainScreen.Bounds.Width, 1.0f),
                MasksToBounds = true
            };
        }

        private void UpdateFocusedBackground()
        {
            this.focusedBackground = new CALayer
            {
                BorderColor = this.Element.FocusedLineColor.ToCGColor(),
                BorderWidth = this.Element.FocusedLineWidth,
                Frame = new CGRect(0.0f, 30, UIScreen.MainScreen.Bounds.Width, 1.0f),
                MasksToBounds = true
            };
        }
        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            DrawBorder(this.focusedBackground);
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            DrawBorder(this.unFocusedBackground);
        }


        //public override void Draw(CGRect rect)
        //{
        //    //get graphics context
        //    CGContext gctx = UIGraphics.GetCurrentContext();

        //    base.Draw(rect);
        //    rect = new CGRect(0.0f, 20, UIScreen.MainScreen.Bounds.Width, 1.0f);
        //    // get graphics context
        //    CGContext context = UIGraphics.GetCurrentContext();

        //    var color = UIColor.Black;
        //    // set up drawing attributes
        //    color.SetStroke();
        //    color.SetFill();

        //    nfloat lineWidth = 0;
        //    nfloat xStartPosition = 0;
        //    nfloat yStartPosition = 0;
        //    nfloat xEndPosition = 0;
        //    nfloat yEndPosition = 0;

        //    // vertical line
        //    lineWidth = rect.Width;
        //    // Move the path down by half of the line width so it doesn't straddle pixels.
        //    xStartPosition = rect.X + lineWidth * 0.5f;
        //    yStartPosition = rect.Y;
        //    xEndPosition = xStartPosition;
        //    yEndPosition = rect.Y + rect.Height;

        //    // start point
        //    context.MoveTo(0, yStartPosition);

        //    // end point
        //    context.AddLineToPoint(320, yEndPosition);

        //    context.SetLineWidth(lineWidth;
        //    // draw the path
        //    context.DrawPath(CGPathDrawingMode.Stroke);
        //}

    }

    class NoBackgroundEntry : PlatformEffect
    {
        public NoBackgroundEntry()
        {

        }
        protected override void OnAttached()
        {
            if (Control != null)
                ((UITextField)Control).BorderStyle = UITextBorderStyle.None;
        }

        protected override void OnDetached()
        {
        }
    }
}
