using TestApp.Renderers;
using Xamarin.Forms;

namespace TestApp.Views.Auth
{
    public partial class MyProfilePage : ContentPage
    {
        public MyProfilePage()
        {
            InitializeComponent();
            AdjustViewsWidth();
            AddToolbarItems();
        }

        void MaleBtn_Clicked(object sender, System.EventArgs e)
        {
            var classId = ((Button)sender).ClassId;
            this.ToggleButtonColor(classId);
        }

        void FemaleBtn_Clicked(object sender, System.EventArgs e)
        {
            var classId = ((Button)sender).ClassId;
            this.ToggleButtonColor(classId);
        }

		void CustomBtn_Clicked(object sender, System.EventArgs e)
		{
			var classId = ((Button)sender).ClassId;
			this.ToggleButtonColor(classId);
		}

        void LocationVisibleBtn_Clicked(object sender, System.EventArgs e)
        {
			var classId = ((Button)sender).ClassId;
			this.ToggleButtonColor(classId);
        }

		void LocationNotVisibleBtn_Clicked(object sender, System.EventArgs e)
		{
			var classId = ((Button)sender).ClassId;
			this.ToggleButtonColor(classId);
		}

        void BugImage_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new BugsPage());
        }

        private void AdjustViewsWidth()
        {
            MaleButton.WidthRequest = App.ScreenWidth * 0.25;
            FemaleButton.WidthRequest = App.ScreenWidth * 0.25;
            CustomButton.WidthRequest = App.ScreenWidth * 0.25;
        }

		private void AddToolbarItems()
		{
            ToolbarItem saveToolbarItem = new ToolbarItem();
			saveToolbarItem.Priority = 0;
			saveToolbarItem.Order = ToolbarItemOrder.Primary;
            saveToolbarItem.Text = "Save";
			this.ToolbarItems.Add(saveToolbarItem);
		}

        private void ToggleButtonColor(string classId)
        {
            switch (classId)
            {
                case "MaleBtn":
                    MaleButton.BackgroundColor = (Color)App.Current.Resources["NavBarItem"];
                    FemaleButton.BackgroundColor = Color.Transparent;
                    CustomButton.BackgroundColor = Color.Transparent;
                    break;
                case "FemaleBtn":
                    MaleButton.BackgroundColor = Color.Transparent;
					FemaleButton.BackgroundColor = (Color)App.Current.Resources["NavBarItem"];
					CustomButton.BackgroundColor = Color.Transparent;
                    break;
				case "CustomBtn":
					MaleButton.BackgroundColor = Color.Transparent;
                    FemaleButton.BackgroundColor = Color.Transparent;
					CustomButton.BackgroundColor = (Color)App.Current.Resources["NavBarItem"];
					break;
				case "VisibleBtn":
					LocationNotVisibleBtn.BackgroundColor = Color.Transparent;
                    LocationVisibleBtn.BackgroundColor = (Color)App.Current.Resources["NavBarItem"];
					break;
				case "NotVisibleBtn":
					LocationVisibleBtn.BackgroundColor = Color.Transparent;
					LocationNotVisibleBtn.BackgroundColor = (Color)App.Current.Resources["NavBarItem"];
					break;
            }
        }
    }
}
