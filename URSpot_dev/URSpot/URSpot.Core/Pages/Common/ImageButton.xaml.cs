using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace URSpot.Core.Pages.Common
{
    public partial class ImageButton : ContentView
    {
        public ImageButton()
        {
            InitializeComponent();
            PART_Image.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    this.IconTapped?.Invoke(this, EventArgs.Empty);
                    var cmd = this.IconTappedCommand ?? this.TappedCommand;
                    if (cmd?.CanExecute(this.IconTappedCommandParameter) ?? false)
                    {
                        cmd?.Execute(this.IconTappedCommandParameter);
                    }
                },
                () => this.IconTapped != null || this.IconTappedCommand != null || this.TappedCommand != null)
            });

            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    var cmd = this.TappedCommand;
                    var param = this.TappedCommandParameter;
                    if (cmd?.CanExecute(param) ?? false)
                    {
                        cmd?.Execute(param);
                    }
                },
               () => this.TappedCommand != null)
            });
        }

        event EventHandler IconTapped;


        public ICommand IconTappedCommand
        {
            get { return (ICommand)GetValue(IconTappedCommandProperty); }
            set { SetValue(IconTappedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconTappedCommand.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty IconTappedCommandProperty =
            BindableProperty.Create("IconTappedCommand", typeof(ICommand), typeof(ImageButton), null);


        public object IconTappedCommandParameter
        {
            get { return (object)GetValue(IconTappedCommandParameterProperty); }
            set { SetValue(IconTappedCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconTappedCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty IconTappedCommandParameterProperty =
            BindableProperty.Create("IconTappedCommandParameter", typeof(object), typeof(ImageButton), null);

        public ICommand TappedCommand
        {
            get { return (ICommand)GetValue(TappedCommandProperty); }
            set { SetValue(TappedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TappedCommand.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TappedCommandProperty =
            BindableProperty.Create("TappedCommand", typeof(ICommand), typeof(ImageButton), null);



        public ICommand TappedCommandParameter
        {
            get { return (ICommand)GetValue(TappedCommandParameterProperty); }
            set { SetValue(TappedCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TappedCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TappedCommandParameterProperty =
            BindableProperty.Create("TappedCommandParameter", typeof(ICommand), typeof(ImageButton), null);



        public ElementPosition ImagePosition
        {
            get { return (ElementPosition)GetValue(ImagePositionProperty); }
            set { SetValue(ImagePositionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImagePosition.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ImagePositionProperty =
            BindableProperty.Create("ImagePosition", typeof(ElementPosition), typeof(ImageButton), ElementPosition.Left, propertyChanged: (t, o, n) =>
            {
                var target = t as ImageButton;
                var pos = (int)(ElementPosition)n;
                if ((pos & 4) != 0) //0b100
                {
                    Grid.SetRow(target.PART_Image, pos & 3); //0b11
                    Grid.SetColumn(target.PART_Image, 1);
                }
                else
                {
                    Grid.SetRow(target.PART_Image, 1);
                    Grid.SetColumn(target.PART_Image, pos);
                }
            });


        public float LineWidth
        {
            get { return (float)GetValue(LineWidthProperty); }
            set { SetValue(LineWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineWidth.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty LineWidthProperty =
            BindableProperty.Create("LineWidth", typeof(float), typeof(ImageButton), 1f);



        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineColor.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty LineColorProperty =
            BindableProperty.Create("LineColor", typeof(Color), typeof(ImageButton), Color.Gray);

        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty IconProperty =
            BindableProperty.Create("Icon", typeof(ImageSource), typeof(ImageButton), null);

        public Thickness ContentMargin
        {
            get { return (Thickness)GetValue(ContentMarginProperty); }
            set { SetValue(ContentMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentMargin.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ContentMarginProperty =
            BindableProperty.Create("ContentMargin", typeof(Thickness), typeof(ImageButton), new Thickness());

        public NamedSize NamedSize
        {
            get { return (NamedSize)GetValue(NamedSizeProperty); }
            set { SetValue(NamedSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontSize.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty NamedSizeProperty =
            BindableProperty.Create("NamedSize", typeof(NamedSize), typeof(ImageButton), NamedSize.Default);


        public static readonly BindableProperty IconTintColorProperty = BindableProperty.Create(nameof(IconTintColor), typeof(Color), typeof(ImageButton), Color.Black);

        public Color IconTintColor
        {
            get { return (Color)GetValue(IconTintColorProperty); }
            set { SetValue(IconTintColorProperty, value); }
        }


        public Thickness IconMargin
        {
            get { return (Thickness)GetValue(IconMarginProperty); }
            set { SetValue(IconMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconMargin.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty IconMarginProperty =
            BindableProperty.Create("IconMargin", typeof(Thickness), typeof(ImageButton), new Thickness(0));


    }
}
