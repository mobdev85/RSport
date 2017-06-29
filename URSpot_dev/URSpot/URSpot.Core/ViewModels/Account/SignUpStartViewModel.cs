using System;
using URSpot.Core.ViewModels.Base;
using MvvmCross.Core.ViewModels;
using Xamarin.Forms;
using URSpot.Core.Utils;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using URSpot.Core.Services;

namespace URSpot.Core.ViewModels.Account
{
    public class SignUpStartViewModel: BaseNavigationViewModel
    {
        public SignUpStartViewModel()
        {
            this.CurrentNavigationBarItem = NavigationBarItem.Home;
            this.IsNavigationVisible = true;
        }

        public MvxCommand SignUpFacebookCommand => new MvxCommand(() => ShowViewModel<FacebookLoginViewModel>());

        FacebookViewModel _Filters;
        public FacebookViewModel Filters
        {
            get { return _Filters; }
            set { SetProperty(ref this._Filters, value); }
        }

        public void SetInitialSettings(FacebookViewModel facebookViewModel)
        {
            this.Filters = facebookViewModel;

        }
    }
}
