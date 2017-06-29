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
using Android.Content.PM;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Platform;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Presenter.Droid;
using MvvmCross.Core.ViewModels;
using Xamarin;
using Android.Graphics.Drawables;
using Android.Text;
using Acr.UserDialogs;
using Plugin.Media;
using URSpot.Core;

namespace URSpot.Droid
{
	[Activity(Label = "@string/ApplicationName", ScreenOrientation = ScreenOrientation.Portrait, Icon = "@drawable/Icon")]
	public class MvxFormsApplicationActivity
		: FormsApplicationActivity
	{
        protected override async void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			Forms.Init(this, bundle);

			App.ScreenWidth = (int)Resources.DisplayMetrics.WidthPixels;
			App.ScreenHeight = (int)Resources.DisplayMetrics.HeightPixels;

            //FormsMaps.Init(this, bundle);
            Xamarin.FormsGoogleMaps.Init(this, bundle);
            await CrossMedia.Current.Initialize();
            //Remove the icon in the navigation bar
           // ActionBar.SetIcon(Android.Resource.Color.Transparent);
            //ActionBar.SetBackgroundDrawable(new ColorDrawable(Xamarin.Forms.Color.FromHex("#aa80ff").ToAndroid()));

            var mvxFormsApp = new Core.App();
			LoadApplication(mvxFormsApp);

			var presenter = Mvx.Resolve<IMvxViewPresenter>() as MvxFormsDroidPagePresenter;
			presenter.MvxFormsApp = mvxFormsApp;

            UserDialogs.Init(this);

            Mvx.Resolve<IMvxAppStart>().Start();
        }
	}
}

