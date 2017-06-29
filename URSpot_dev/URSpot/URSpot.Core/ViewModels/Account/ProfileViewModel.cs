using System;
using MvvmCross.Core.ViewModels;
using URSpot.Core.ViewModels.Base;

namespace URSpot.Core.ViewModels.Account
{
    public class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel()
        {
            this.CurrentNavigationBarItem = NavigationBarItem.Profile;
        }

        public double CellWidth
        {
            get { return App.ScreenWidth * 0.40; }
        }

        public MvxCommand MyProfileCommand => new MvxCommand(() => ShowViewModel<MyProfileViewModel>());
        public MvxCommand BugCommand => new MvxCommand(() => ShowViewModel<BugViewModel>());
    }
}
