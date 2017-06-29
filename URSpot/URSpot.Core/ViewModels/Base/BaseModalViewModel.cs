using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmValidation;
using URSpot.Core.Utils;

namespace URSpot.Core.ViewModels.Base
{
    public class BaseModalViewModel : BaseViewModel
    {
        public BaseModalViewModel() : base()
        {
            this.DismissIcon = ImageSource.FromResource("Andey.Core.Images.Icons.ic_close_black@2x.png");
        }
        
        private bool _IsActionLabelVisible;
        public bool IsActionLabelVisible
        {
            get { return _IsActionLabelVisible; }
            set { SetProperty(ref _IsActionLabelVisible, value); }
        }

        private string _ActionText;
        public virtual string ActionText
        {
            get { return _ActionText; }
            set { SetProperty(ref _ActionText, value); }
        }

        public virtual ICommand ActionCommand
        {
            get
            {
                return new MvxCommand(()=>{

                });
            }
        }

        public virtual ICommand DismissCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    this.DismissCurrentModalOverlay();
                });
            }
        }

        private ImageSource _DismissIcon;
        public virtual ImageSource DismissIcon
        {
            get { return _DismissIcon; }
            set
            {
                SetProperty(ref _DismissIcon, value);
            }
        }

        protected virtual Task<ValidationResult> ConfigureValidationRules()
        {
            return null;
        }
    }
}
