using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TestApp.Views
{
    public partial class BugsPage : ContentPage
    {
        public BugsPage()
        {
            InitializeComponent();
            SetViewWidths();
        }

        private void SetViewWidths()
        {
            SendBugButton.WidthRequest = App.ScreenWidth * 0.75;
        }
    }
}
