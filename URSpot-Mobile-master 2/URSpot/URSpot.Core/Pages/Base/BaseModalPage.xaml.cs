using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace URSpot.Core.Pages.Base
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseModalPage : ContentView
    {
        public BaseModalPage()
        {
            InitializeComponent();
        }
    }
}
