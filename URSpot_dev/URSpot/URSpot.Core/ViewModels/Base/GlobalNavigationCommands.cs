
using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using URSpot.Core.ViewModels.Account;
using Xamarin.Forms;

namespace URSpot.Core.ViewModels.Base
{
    public class GlobalNavigationCommands : MvxViewModel
    {
        public ICommand GoToSignIn
        {
            get { return this.GoTo<SignUpStartViewModel>(); }
        }

        public ICommand GoToHome
        {
            //get { return this.GoTo<HomeViewModel>(); }
            get { return this.GoTo<LaunchViewModel>(); }
        }

        public ICommand GoToFriends
        {
            //get { return this.GoTo<FriendsViewModel>(); }
            get { return this.GoTo<SignUpStartViewModel>(); }
        }

        public ICommand GoToFavourites
        {
            //get { return this.GoTo<FavouritesViewModel>(); }
            get { return this.GoTo<SignUpStartViewModel>(); }
        }


        public ICommand GoToProfile
        {
            //get { return this.GoTo<ProfileSettingsViewModel>(); }
            get { return this.GoTo<ProfileViewModel>(); }
        }

        public ICommand GoTo<TViewModel>()
            where TViewModel : IMvxViewModel
        {
            return new Command(() =>
            {
                var mainPage = Application.Current.MainPage as NavigationPage;
                var currentPage = mainPage?.CurrentPage;
                if (currentPage?.BindingContext is TViewModel) return;

                this.ShowViewModel<TViewModel>();
            });
        }
    }
}
