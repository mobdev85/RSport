using System.Collections.Generic;
using TestApp.iOS.Renderers;
using TestApp.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomContentPage), typeof(CustomContentPageRenderer))]
namespace TestApp.iOS.Renderers
{
    public class CustomContentPageRenderer : PageRenderer
    {
		public new CustomContentPage Element
		{
			get
			{
				return (CustomContentPage)base.Element;
			}
		}

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
			var leftNavList = new List<UIBarButtonItem>();
			var rightNavList = new List<UIBarButtonItem>();
			var navigationItem = this.NavigationController.TopViewController.NavigationItem;
			Color navItemColor = (Color)Xamarin.Forms.Application.Current.Resources["NavBarItem"];

			System.Console.WriteLine("Navigation Item Count: " + Element.ToolbarItems.Count.ToString());

			for (var i = 0; i < Element.ToolbarItems.Count; i++)
			{
				var reorder = Element.ToolbarItems.Count - 1;
				var itemPriority = Element.ToolbarItems[reorder - i].Priority;

				if (itemPriority == 1)
				{
					UIBarButtonItem leftNavItems = navigationItem.RightBarButtonItems[i];
					leftNavList.Add(leftNavItems);
				}
				else if (itemPriority == 0)
				{
					UIBarButtonItem RightNavItems = navigationItem.RightBarButtonItems[i];
					rightNavList.Add(RightNavItems);
				}
			}

			navigationItem.SetLeftBarButtonItems(leftNavList.ToArray(), false);
			navigationItem.SetRightBarButtonItems(rightNavList.ToArray(), false);
        }
    }
}
