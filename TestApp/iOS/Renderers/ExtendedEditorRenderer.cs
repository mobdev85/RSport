using CoreGraphics;
using TestApp.iOS.Renderers;
using TestApp.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedEditor), typeof(ExtendedEditorRenderer))]
namespace TestApp.iOS.Renderers
{
    public class ExtendedEditorRenderer : EditorRenderer
    {
        private string Placeholder { get; set; }
        private Color PlaceholderColor { get; set; }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            var element = e.NewElement as ExtendedEditor;

            if (Control != null && element != null)
            {
                Placeholder = element.Placeholder;
                PlaceholderColor = element.PlaceholderColor;
                Control.Text = Placeholder;
                Control.TextAlignment = UITextAlignment.Center;

                Control.ShouldBeginEditing += (UIKit.UITextView textView) => {
                    if (textView.Text == Placeholder)
                    {
                        textView.Text = "";
                        textView.TextColor = element.TextColor.ToUIColor() ?? Color.White.ToUIColor();
                    }
                    return true;
                };

                Control.ShouldEndEditing += (UIKit.UITextView textView) => {
					if (textView.Text == "")
					{
						textView.Text = Placeholder;
                        textView.TextColor = PlaceholderColor.ToUIColor() ?? Color.Silver.ToUIColor();
					}
                    return true;
                };

            }
        }
    }
}
