using MvvmCross.Platform.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using UIKit;
using Xamarin.Forms;
using MvvmCross.Forms.Presenter.iOS;
using MvvmCross.Forms.Presenter.Core;
using System.Collections.Generic;
using MvvmCross.Core.Views;
using System;
using URSpot.Core.ViewModels.Account;
using MvvmCross.Platform;
using URSpot.Core.Pages.Account;

namespace URSpot.iOS
{
	public class Setup : MvxIosSetup
    {
        const string MapsApiKey = "AIzaSyAxNviCHKM5aEFIAp0WepDvhhqs1d2yjPM";
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
			: base(applicationDelegate, window)
		{
        }
        public Setup(MvxApplicationDelegate appDelegate, IMvxIosViewPresenter presenter)
           : base(appDelegate, presenter)
        {
        }
        protected override IMvxApplication CreateApp()
		{
			return new Core.MvxApplication();
		}

		protected override IMvxTrace CreateDebugTrace()
		{
			return new DebugTrace();
        }
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
        }

        protected override IMvxIosViewPresenter CreatePresenter()
		{	Forms.Init();
            //Xamarin.FormsMaps.Init();
            Xamarin.FormsGoogleMaps.Init(MapsApiKey);
            var xamarinFormsApp = new Core.App();

            var presenter = new MvxFormsIosPagePresenter(Window, xamarinFormsApp);
			return presenter;
		}

        protected override void InitializeViewLookup()
        {
            base.InitializeViewLookup();


            var vmLookup = new Dictionary<Type, Type>
            {
                {typeof (LaunchViewModel), typeof (LaunchPage)}
            };

            var container = Mvx.Resolve<IMvxViewsContainer>();
            container.AddAll(vmLookup);
        }

        //protected override IEnumerable<Assembly> GetViewAssemblies()
        //{
        //    var result = base.GetViewAssemblies();
        //    var assemblyList = result.ToList();
        //    assemblyList.Add(typeof(SignUp1Page).Assembly);
        //    return assemblyList;
        //}
    }
    //public class MyMvxFormsIosPagePresenter : MvxFormsIosPagePresenter
    //{
    //    public MyMvxFormsIosPagePresenter(UIWindow window, Xamarin.Forms.Application mvxFormsApp)
    //        :base(window, mvxFormsApp)
    //    {

    //    }
    //    //protected override void Trace(string format, params object[] args)
    //    //{
    //    //    Console.WriteLine(format, args);
    //    //}
    //}
}
