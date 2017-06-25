using CoreAnimation;
using Foundation;
using TestApp.iOS.Renderers;
using TestApp.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NoBorderEntry), typeof(NoBorderEnrtyRenderer))]
namespace TestApp.iOS.Renderers
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
