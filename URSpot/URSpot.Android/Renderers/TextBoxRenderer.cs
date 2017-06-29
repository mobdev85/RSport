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
using URSpot.Core.Pages.Common;
using Xamarin.Forms.Platform.Android;
using URSpot.Droid;
using System.ComponentModel;
using Android.Graphics;

[assembly: ExportRenderer(typeof(TextBox), typeof(TextBoxRenderer))]
namespace URSpot.Droid
{
    public class TextBoxRenderer : ViewRenderer<TextBox, Android.Views.View>
    {
        private Entry entry;
        private BorderDrawable focusedBackground;
        private BorderDrawable unFocusedBackground;

        public TextBoxRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<TextBox> e)
        {
            base.OnElementChanged(e);
            if (this.Control == null)
            {
                this.SetNativeControl(new Android.Views.View(Context));
            }
            if (this.Control != null)
            {
                this.UpdateFocusedBackground();
                this.UpdateUnFocusedBackground();
                this.Control.SetBackground(this.unFocusedBackground);
                //this.Control.SetBackgroundResource(Resource.Drawable.EditText);
                this.entry = e.NewElement.Content.FindByName<Entry>("PART_Entry");
           
                entry.Effects.Add(new NoBackgroundEntry());
                entry.Unfocused += Entry_Unfocused;
                entry.Focused += Entry_Focused;
                entry.TextColor = Xamarin.Forms.Color.White;
            }

        }

        private void UpdateUnFocusedBackground()
        {
            this.unFocusedBackground = new BorderDrawable(new Paint
            {
                Color = this.Element.LineColor.ToAndroid(),
                StrokeWidth = this.Element.LineWidth,
            });
        }

        private void UpdateFocusedBackground()
        {
            this.focusedBackground = new BorderDrawable(new Paint
            {
                Color = this.Element.FocusedLineColor.ToAndroid(),
                StrokeWidth = this.Element.FocusedLineWidth,
            });
        }
        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            if (this.Control != null)
                this.Control.Background = this.focusedBackground;
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            if (this.Control != null)
                this.Control.Background = this.unFocusedBackground;
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
                canvas.DrawLine(5, canvas.Height - 5, canvas.Width, canvas.Height - 5, this.paint);
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


        class NoBackgroundEntry : PlatformEffect
        {
            public NoBackgroundEntry()
            {

            }
            protected override void OnAttached()
            {
                this.Control?.SetBackground(null);
            }

            protected override void OnDetached()
            {
            }
        }
    }
}