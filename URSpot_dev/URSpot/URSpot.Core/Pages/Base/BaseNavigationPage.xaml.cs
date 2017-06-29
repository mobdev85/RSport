using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using URSpot.Core.Pages.Common;
using URSpot.Core.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace URSpot.Core.Pages.Base
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseNavigationPage : BasePage
    {
        public BaseNavigationPage()
        {
            InitializeComponent();
            PART_Modal = this.FindTemplateElementByName<ContentView>("PART_Modal");
            this.IsNavigationVisible = true;
        }

        public bool IsNavigationVisible
        {
            get { return (bool)GetValue(IsNavigationVisibleProperty); }
            set { SetValue(IsNavigationVisibleProperty, value); }
        }

        public static readonly BindableProperty IsNavigationVisibleProperty =
            BindableProperty.Create("IsNavigationVisible", typeof(bool), typeof(BasePage), true, propertyChanged: (o, on, nv) =>
            {
                ((BaseNavigationPage)o).FindTemplateElementByName<NavigationBarView>("NavigationMenuBar").IsVisible = (bool)nv;
            });
    }
}