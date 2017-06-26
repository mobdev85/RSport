using URSpot.Core.Pages.Common;
using URSpot.Droid;
using Android.Runtime;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using System;
using System.ComponentModel;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(CircleImage), typeof(CircleImageRenderer))]
namespace URSpot.Droid
{
    /// <summary>
    /// CircleImage Implementation
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CircleImageRenderer : ImageRenderer
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }

        protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)
        {
            try
            {
                var cornerRadius = ((CircleImage)Element).BorderRadius;
                var radius = Math.Min(Width, Height) / 2;
                var strokeWidth = 10;
                radius -= strokeWidth / 2;

                //Create path to clip
                var path = new Path();

                var rect = new RectF(0, 0, Width, Height);
                float rx = Forms.Context.ToPixels(cornerRadius);
                float ry = Forms.Context.ToPixels(cornerRadius);

                if (cornerRadius == 0)
                {
                    path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
                }
                else
                {
                    path.AddRoundRect(rect, rx, ry, Path.Direction.Ccw);
                }
                canvas.Save();
                canvas.ClipPath(path);

                var result = base.DrawChild(canvas, child, drawingTime);

                canvas.Restore();

                // Create path for circle border
                path = new Path();
                if (cornerRadius == 0)
                {
                    path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
                }
                else
                {
                    path.AddRoundRect(rect, rx, ry, Path.Direction.Cw);
                }
                var paint = new Paint();
                paint.AntiAlias = true;
                paint.StrokeWidth = 5;
                paint.SetStyle(Paint.Style.Stroke);
                paint.Color = global::Android.Graphics.Color.White;

                canvas.DrawPath(path, paint);

                //Properly dispose
                paint.Dispose();
                path.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to create circle image: " + ex);
            }

            return base.DrawChild(canvas, child, drawingTime);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                //Only enable hardware accelleration on lollipop
                if ((int)Android.OS.Build.VERSION.SdkInt < 21)
                {
                    SetLayerType(LayerType.Software, null);
                }

            }
        }
    }
}