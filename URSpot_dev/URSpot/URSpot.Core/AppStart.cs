using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmCross.Core.ViewModels;
using URSpot.Core.ViewModels.Account;
using MvvmCross.Platform;

namespace URSpot.Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        public async void Start(object hint = null)
        {
            //Mvx.Resolve<IStaticDataRepository>().SyncronizeDatabase();

            //var userManagerService = Mvx.Resolve<IUserManagerService>();



            ShowViewModel<LaunchViewModel>();
   
            var navPage = (Application.Current.MainPage as NavigationPage);
            navPage.PropertyChanged += NavPage_PropertyChanged;

        }

        Page oldPage;
        private void NavPage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentPage")
            {
                var navPage = (Application.Current.MainPage as NavigationPage);
              //  (oldPage?.BindingContext as INavigationAwareViewModel)?.OnDeactivated();
               // (navPage.CurrentPage?.BindingContext as INavigationAwareViewModel)?.OnActivated();
                oldPage = navPage.CurrentPage;
            }
        }

    }
}
