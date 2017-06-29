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

namespace URSpot.Core.ViewModels.Account
{
    public class LaunchViewModel : BaseNavigationViewModel
    {
        public ICommand PageAppearingCommand { get; private set; }
        public ICommand PageDisappearingCommand { get; private set; }
        ///private IApplicationService applicationService;
        private static string Prefix = "URSpot.Core.Images.Launch.";


        public LaunchViewModel()
        {
            this.CurrentNavigationBarItem = NavigationBarItem.Home;
            this.IsNavigationVisible = true;

            PageAppearingCommand = new Command(OnPageAppearing);
            PageDisappearingCommand = new Command(OnPageDisappearing);
            BackgroundImage = ImageSource.FromResource($"{Prefix}URSPOTbackground.jpg");
            //this.applicationService = applicationService;
        }

        private ImageSource backgroundImage;
        public ImageSource BackgroundImage
        {
            get { return backgroundImage; }
            set { this.SetProperty(ref backgroundImage, value); }
        }

        public MvxCommand SignUpCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<SignUpStartViewModel>());
            }
        }

        public MvxCommand SignInCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<LoginViewModel>());
            }
        }

        void OnPageAppearing()
        {
        }

        void OnPageDisappearing()
        {
        }
    }
}
