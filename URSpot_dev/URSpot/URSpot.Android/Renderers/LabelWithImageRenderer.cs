using URSpot.Core.Pages.Common;
using URSpot.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Android.Graphics;

[assembly: ExportRenderer(typeof(LabelWithImage), typeof(LabelWithImageRenderer))]
namespace URSpot.Droid
{
    public class LabelWithImageRenderer : ViewRenderer<LabelWithImage, Android.Views.View>
    {
        private Label label;
        private BorderDrawable background;

        public LabelWithImageRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<LabelWithImage> e)
        {
            base.OnElementChanged(e);
            if (this.Control == null)
            {
                this.SetNativeControl(new Android.Views.View(Context));
            }
            if (this.Control != null)
            {
                this.UpdateBackground();
                this.Control.SetBackground(this.background);
                //this.Control.SetBackgroundResource(Resource.Drawable.EditText);
                this.label = e.NewElement.Content.FindByName<Label>("PART_Entry");
            }

        }


        private void UpdateBackground()
        {
            this.background = new BorderDrawable(new Paint
            {
                Color = this.Element.LineColor.ToAndroid(),
                StrokeWidth = this.Element.LineWidth,
            });
        }

        class BorderDrawable : Android.Graphics.Drawables.Drawable
        {
            private Paint paint;

            public BorderDrawable(Paint paint)
            {
                this.paint = paint;
            }

            public override int Opacity { get { return this.Alpha; } }

            public override void Draw(Canvas canvas)
            {
                if (this.paint.StrokeWidth != 0)
                {
                    canvas.DrawLine(5, canvas.Height - 5, canvas.Width, canvas.Height - 5, this.paint);
                }
            }

            public override void SetAlpha(int alpha)
            {
                this.Alpha = alpha;
            }

            public override void SetColorFilter(ColorFilter colorFilter)
            {

            }
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
            canvas.DrawLine(0, 0, canvas.Width, canvas.Height, new Paint { Color = new Android.Graphics.Color(0xFF0000) });
        }
        public override void UpdateViewLayout(Android.Views.View view, LayoutParams @params)
        {
            base.UpdateViewLayout(view, @params);
        }
    }
}
