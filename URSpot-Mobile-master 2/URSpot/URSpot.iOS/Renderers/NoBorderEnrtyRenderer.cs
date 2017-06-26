using System;
using UIKit;
using URSpot.Core.Pages.Common;
using URSpot.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NoBorderEntry), typeof(NoBorderEnrtyRenderer))]
namespace URSpot.iOS.Renderers
{
    public class NoBorderEnrtyRenderer : EntryRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.BorderStyle = UITextBorderStyle.None;

				var view = (Element as NoBorderEntry);
				if (view != null)
				{
					RemoveBorder(view);
				}
			}
		}

		void RemoveBorder(NoBorderEntry view)
		{
			Control.BorderStyle = UITextBorderStyle.None;
		}
    }
}
