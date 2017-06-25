using Xamarin.Forms;

namespace TestApp.Components
{
    public class Separator : Image
    {
        public Separator()
        {
            this.Source = ImageSource.FromFile("separator.png");
            this.Aspect = Aspect.AspectFill;
            this.WidthRequest = App.ScreenWidth * 0.80;
            this.HeightRequest = 2;
        }
    }
}
