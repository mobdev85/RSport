using TestApp.iOS.Renderers;
using TestApp.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LeftAlignedIconButton), typeof(LeftAlignedIconButtonRenderer))]
namespace TestApp.iOS.Renderers
{
    public class LeftAlignedIconButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Layer.CornerRadius = 22;
                Control.ClipsToBounds = true;
                Control.TitleEdgeInsets = new UIEdgeInsets(0.0f, Control.Center.X / 2, 0.0f, 0.0f);
            }

        }
    }
}
