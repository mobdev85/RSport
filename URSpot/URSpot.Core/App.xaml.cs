using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Plugins;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace URSpot.Core
{
    public partial class App : MvxFormsApp
    {
		public static int ScreenWidth;
		public static int ScreenHeight;

        public App()
        {
            InitializeComponent();
            MainPage = new ContentPage { Title = "LaunchPage" }; // your page here
        }

    }
}
