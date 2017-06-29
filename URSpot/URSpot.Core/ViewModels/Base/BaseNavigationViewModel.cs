using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System.Linq.Expressions;
//using URSpot.Core.Statics;
using MvvmValidation;
using Xamarin.Forms;
using URSpot.Core.Utils;
using System.Windows.Input;
using System.ComponentModel;
using System.Diagnostics;
using Acr.UserDialogs;
using URSpot.Core.Services;
using System.Threading.Tasks;

namespace URSpot.Core.ViewModels.Base
{

    public class BaseNavigationViewModel : BaseViewModel, INavigationAwareViewModel
    {
        public BaseNavigationViewModel() : base()
        {
        }

        #region Selection Region

        private bool _IsNavigationVisible;
        public virtual bool IsNavigationVisible
        {
            get { return _IsNavigationVisible; }
            set { SetProperty(ref _IsNavigationVisible, value); }
        }
        #endregion
    }
}
