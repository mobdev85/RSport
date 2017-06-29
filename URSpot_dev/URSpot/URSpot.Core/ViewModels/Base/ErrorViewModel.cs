
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using URSpot.Core.Utils;
using Xamarin.Forms;

namespace URSpot.Core.ViewModels.Base
{
    public class ErrorViewModel<T> : MvxViewModel
        where T:class
    {
        public ErrorViewModel()
        {
            MessagingCenter.Subscribe<T, string>(this, Messages.DisplayAlert, (s, e) =>
            {
                this.HasError = true;
                this.Error = e;
            });
        }


        bool _HasError;
        public bool HasError
        {
            get { return _HasError; }
            set { SetProperty(ref this._HasError, value); }
        }

        string _Error;
        public string Error
        {
            get { return _Error; }
            set { SetProperty(ref this._Error, value); }
        }

        public ICommand DismissError
        {
            get
            {
                return new MvxCommand(() => this.HasError = false);
            }
        }
    }
}
