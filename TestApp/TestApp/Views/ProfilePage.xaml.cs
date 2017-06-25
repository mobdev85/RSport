using System;
using Xamarin.Forms;

namespace TestApp.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            AdjustFrameWidth();
        }

        private void AdjustFrameWidth()
        {
            profileFrame.WidthRequest = App.ScreenWidth * 0.40;
            socialFrame.WidthRequest = App.ScreenWidth * 0.40;
            paymentFrame.WidthRequest = App.ScreenWidth * 0.40;
            rewardsFrame.WidthRequest = App.ScreenWidth * 0.40;
            inviteFriendsFrame.WidthRequest = App.ScreenWidth * 0.40;
            promotionsFrame.WidthRequest = App.ScreenWidth * 0.40;
            aboutUrspotFrame.WidthRequest = App.ScreenWidth * 0.40;
            signoutFrame.WidthRequest = App.ScreenWidth * 0.40;
        }

        void ProfileCell_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Auth.MyProfilePage());
        }

		void BugImage_Tapped(object sender, EventArgs e)
		{
			Navigation.PushAsync(new BugsPage());
		}
    }
}
