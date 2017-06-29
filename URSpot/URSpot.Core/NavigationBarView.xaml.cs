using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CardiApp.Core.Pages.Common
{
    public partial class NavigationBarView : ContentView
    {
        public NavigationBarView()
        {
           // InitializeComponent();
        }



        public int SelectedNavigation
        {
            get { return (int)GetValue(SelectedNavigationProperty); }
            set { SetValue(SelectedNavigationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedNavigation.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty SelectedNavigationProperty =
            BindableProperty.Create("SelectedNavigation", typeof(int), typeof(NavigationBarView), -1, propertyChanged: (target, oldValue, newValue)=>
            {
               /* var newnIndex = (int)newValue;
                var navBar = (NavigationBarView)target;
                var children = navBar.PART_Grid.Children;
                var selected = (Style)navBar.Resources["selected"];
                var unselected = (Style)navBar.Resources["unselected"];
                for (int i = 0; i< children.Count;i++)
                {
                    if (i == newnIndex)
                    {
                        children[i].Style = selected;
                    }
                    else
                    {
                        children[i].Style = unselected;
                    }
                }*/
            });
        
    }
}
