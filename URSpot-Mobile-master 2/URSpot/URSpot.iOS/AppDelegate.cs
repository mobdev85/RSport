using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using MvvmCross.iOS.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
//using URSpot.Core.Behaviors;
using MvvmCross.iOS.Views.Presenters;
using Google.Maps;
using URSpot.Core;

namespace URSpot.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate
    {
        UIWindow _window;
        public RootViewController RootViewController { get { return _window.RootViewController as RootViewController; } }
        const string MapsApiKey = "AIzaSyAxNviCHKM5aEFIAp0WepDvhhqs1d2yjPM";

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            _window = new UIWindow(UIScreen.MainScreen.Bounds);
            var setup = new Setup(this, _window);
            setup.Initialize();

            //Initialize syncfusion components
            //new SfCalendarRenderer();
            //new SfNumericUpDownRenderer();
            //new SfRangeSliderRenderer();

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();
            _window.MakeKeyAndVisible();
            Xamarin.FormsGoogleMaps.Init(MapsApiKey);

			App.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;
			App.ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;

            //UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            //{
            //    TextColor = UIColor.Purple
            //});

            //UINavigationBar.Appearance.BarTintColor = UIColor.White;
            UINavigationBar.Appearance.TintColor = new UIColor(red: 0.67f, green: 0.50f, blue: 1.00f, alpha: 1.0f);

            return true;
        }
    }
    public class RootViewController : UIViewController
    {
        private UIViewController root;

        public RootViewController(UIViewController root)
        {
            this.root = root;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}
