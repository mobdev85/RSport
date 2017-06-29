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
    public class BaseViewModel : MvxViewModel, INotifyPropertyChanged, INavigationAwareViewModel
    {
        public BaseViewModel()
        {
            this.CurrentNavigationBarItem = NavigationBarItem.Home;
        }
        public NavigationBarItem CurrentNavigationBarItem { get; set; }

        public GlobalNavigationCommands Global { get; } = new GlobalNavigationCommands();

        private IBusyService busyService;

        public IBusyService BusyService
        {
            get
            {
                return busyService ?? (busyService = Mvx.Resolve<IBusyService>());
            }
        }


        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                if (SetProperty(ref title, value))
                    RaisePropertyChanged(() => Title);

            }

        }

        /// <returns>An instance of the service.</returns>
        public TService GetService<TService>() where TService : class
        {
            return Mvx.Resolve<TService>();
        }

        protected void DisplayAlert(string message)
        {
            Message = message;
            //HasMessage = true;
            MessagingCenter.Send(this, Messages.DisplayAlert, message);
        }

        protected void WriteLog(string message)
        {
            Debug.WriteLine(message);
        }



        protected void DisplayError(string message)
        {
            Message = message;
            HasMessage = true;

        }

        protected void DisplayError(ValidationResult results)
        {
            Message = string.Empty;
            foreach (var item in results.ErrorList)
            {
                Message += item.ErrorText + Environment.NewLine;
            }
            HasMessage = !results.IsValid;
        }

        public event EventHandler Activated;
        public event EventHandler Deactivated;
        public virtual void OnActivated()
        {
            this.Activated?.Invoke(this, EventArgs.Empty);
        }

        public virtual void OnDeactivated()
        {
            this.Deactivated?.Invoke(this, EventArgs.Empty);
        }

        bool hasMessage;
        public bool HasMessage
        {
            get { return this.hasMessage; }
            set
            {
                if (SetProperty(ref hasMessage, value))
                    RaisePropertyChanged(() => HasMessage);

            }
        }

        string message;
        public string Message
        {
            get { return this.message; }
            set
            {
                if (SetProperty(ref message, value))
                    RaisePropertyChanged(() => Message);

            }
        }

        public ICommand DismissMessage
        {
            get
            {
                return new MvxCommand(() => this.HasMessage = false);
            }
        }
    }

    public enum NavigationBarItem
    {
        None = -1,
        Home = 0,
        Favourites = 1,
        Friends = 2,
        Profile = 3,
        SignIn = 4,
    }
}
