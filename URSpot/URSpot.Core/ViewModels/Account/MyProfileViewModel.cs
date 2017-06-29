using System;
using MvvmCross.Core.ViewModels;
using URSpot.Core.ViewModels.Base;

namespace URSpot.Core.ViewModels.Account
{
    public class MyProfileViewModel : BaseNavigationViewModel
    {
        public MyProfileViewModel()
        {
            this.CurrentNavigationBarItem = NavigationBarItem.Profile;
            this.IsNavigationVisible = true;
        }

        public MvxCommand BugCommand => new MvxCommand(() => ShowViewModel<BugViewModel>());
    }
}
