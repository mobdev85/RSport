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
using Xamarin.Forms.Platform.Android;
using URSpot.Core.Pages.Common;
using URSpot.Droid.Renderers;
using Xamarin.Forms;
using System.ComponentModel;
using Android.Graphics;

[assembly: ExportRenderer(typeof(TintedImage), typeof(TintedImageRenderer))]
namespace URSpot.Droid.Renderers
{
    public class TintedImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            SetTint();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == TintedImage.TintColorProperty.PropertyName)
                SetTint();
        }

        void SetTint()
        {
            if (Control != null && Element != null)
            {
                var colorFilter = new PorterDuffColorFilter(((TintedImage)Element).TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                Control.SetColorFilter(colorFilter);
            }
        }
    }
}