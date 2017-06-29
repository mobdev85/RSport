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
using MvvmValidation;

namespace URSpot.Core.ViewModels.Account
{
    public class LoginViewModel : BaseViewModel
    {

        //private IUserManagerService userManagerService;

        public LoginViewModel()//(IUserManagerService userManagerService)
        {
            Title = "Login Page";

            //this.userManagerService = userManagerService;
            IsPassword = true;

        }
        private string username;

        public string Username
        {
            get { return username; }
            set { this.SetProperty(ref username, value); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { this.SetProperty(ref password, value); }
        }

        public MvxCommand LoginCommand
        {
            get
            {
                return new MvxCommand(() => Login());
            }
        }

        private bool isPassword;
        public bool IsPassword
        {
            get { return this.isPassword; }
            set
            {
                if (this.SetProperty(ref isPassword, value))
                {
                    this.RaisePropertyChanged(() => this.Show_Hide);
                }
            }
        }

        public string Show_Hide
        {
            get { return IsPassword ? "Show" : "Hide"; }
        }

        public ICommand ShowPassword
        {
            get
            {
                return new Command(() => IsPassword = !IsPassword);
            }
        }

        public MvxCommand SignUpCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<LaunchViewModel>());
            }
        }

        public MvxCommand ForgotPasswordCommand
        {
            get
            {
                return null;//new MvxCommand(() => ShowViewModel<ForgotPasswordViewModel>());
            }
        }
        public MvxCommand ForgotUsernameCommand
        {
            get
            {
                return null;//new MvxCommand(() => ShowViewModel<ForgotUsernameViewModel>());
            }
        }

        private async void Login()
        {
            //this.Username = "Adela31";
            //this.Password = "Pass@1234";
            var results = ConfigureValidationRules();

            if (results != null && !results.IsValid)
            {
                DisplayError(results);
                return;
            }
            return;
            //using (this.BusyService.BeginBusy())
            //{
            //    var result = await this.userManagerService.LoginAsync(Username, Password);

            //    if (result.Ack == AckCode.SUCCESS)
            //    {
            //        DisplayError("Yeah! valid login");
            //        ShowViewModel<ProfileClientSettingsViewModel>();
            //    }
            //    else
            //    {
            //        Password = string.Empty;
            //        DisplayError(result.Message);
            //        //               ShowViewModel<MyJobsViewModel>();
            //    }
            //}
        }

        protected ValidationResult ConfigureValidationRules()
        {
            var validator = new ValidationHelper();

            validator.AddRequiredRule(() => Username, "Username is required.");
            validator.AddRequiredRule(() => Password, "Password is required.");

            return validator.ValidateAll();

        }
    }
}
