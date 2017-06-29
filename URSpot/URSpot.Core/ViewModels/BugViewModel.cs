using System;
using MvvmCross.Core.ViewModels;
using URSpot.Core.ViewModels.Base;

namespace URSpot.Core.ViewModels
{
    public class BugViewModel : BaseNavigationViewModel
    {
        public BugViewModel()
        {
            this.CurrentNavigationBarItem = NavigationBarItem.Home;
            this.IsNavigationVisible = true;
        }

    }
}
