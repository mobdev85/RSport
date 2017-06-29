using Android.Content;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Presenter.Droid;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using URSpot.Droid;
//using Com.Syncfusion.Calendar;

namespace URSpot.Droid
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext)
			: base(applicationContext)
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

		protected override IMvxAndroidViewPresenter CreateViewPresenter()
		{
			var presenter = new MvxFormsDroidPagePresenter();
			Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            //Initialize controls
            //var ctlCalendar = typeof(SfCalendar);
            //var ctlNumericDD = typeof(SfNumericUpDown);

            return presenter;
		}
	}
}
