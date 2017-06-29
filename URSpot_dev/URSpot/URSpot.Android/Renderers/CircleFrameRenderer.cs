using URSpot.Core.Pages.Common;
using URSpot.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using System.ComponentModel;
using Android.OS;
using Android.Graphics;
using Java.Lang;
using Android.Views;
using AButton = Android.Widget.Button;
using ACanvas = Android.Graphics.Canvas;
using GlobalResource = Android.Resource;
using System;

[assembly: ExportRenderer(typeof(CircleFrame), typeof(CircleFrameRenderer))]
namespace URSpot.Droid
{
    /// <summary>
    /// CircleFrame Implementation
    /// </summary>
    public class CircleFrameRenderer : FrameRenderer
    {
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

            if (e.OldElement != null)
            {
                return;
            }
            this.SetBackgroundColor(Android.Graphics.Color.Transparent);
            this.SetBackground(new CircleFrameDrawable((CircleFrame)this.Element));
            //Only enable hardware accelleration on lollipop
            if ((int)Build.VERSION.SdkInt < 21)
            {
                SetLayerType(LayerType.Software, null);
            }

        }

        class CircleFrameDrawable : Drawable
        {
            private CircleFrame element;

            public CircleFrameDrawable(CircleFrame element)
            {
                this.element = element;
            }

            public override int Opacity => 0;

            public override void Draw(ACanvas canvas)
            {
                var e = this.element;

                DrawRect(canvas, canvas.Width, canvas.Height, e.BorderRadius, 0, e.BackgroundColor.ToAndroid(), Paint.Style.Fill);
                DrawRect(canvas, canvas.Width, canvas.Height, e.BorderRadius, e.BorderThickness, e.BorderColor.ToAndroid(), Paint.Style.Stroke);
            }

            public override void SetAlpha(int alpha)
            {
            }

            public override void SetColorFilter(ColorFilter colorFilter)
            {
            }

            void DrawRect(ACanvas canvas, int width, int height, float cornerRadius, float strokeWidth, Android.Graphics.Color color, Paint.Style style)
            {
                using (var paint = new Paint { AntiAlias = true })
                using (var path = new Path())
                using (Path.Direction direction = Path.Direction.Cw)
                using (style)
                using (var rect = new RectF(0, 0, width, height))
                {
                    cornerRadius -= strokeWidth / 2;

                    float rx = Forms.Context.ToPixels(cornerRadius);
                    float ry = Forms.Context.ToPixels(cornerRadius);
                    path.AddRoundRect(rect, rx, ry, direction);

                    paint.StrokeWidth = strokeWidth;
                    paint.SetStyle(style);
                    paint.Color = color;

                    canvas.DrawPath(path, paint);
                }
            }
        }
    }
}