using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace URSpot.Core.Pages.Common
{

    public partial class LabelWithImage : ContentView
    {
        public LabelWithImage()
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
                ()=> this.IconTapped != null || this.IconTappedCommand != null || this.TappedCommand != null)
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
            BindableProperty.Create("IconTappedCommand", typeof(ICommand), typeof(LabelWithImage), null);
        

        public object IconTappedCommandParameter
        {
            get { return (object)GetValue(IconTappedCommandParameterProperty); }
            set { SetValue(IconTappedCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconTappedCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty IconTappedCommandParameterProperty =
            BindableProperty.Create("IconTappedCommandParameter", typeof(object), typeof(LabelWithImage), null);
        
        public ICommand TappedCommand
        {
            get { return (ICommand)GetValue(TappedCommandProperty); }
            set { SetValue(TappedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TappedCommand.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TappedCommandProperty =
            BindableProperty.Create("TappedCommand", typeof(ICommand), typeof(LabelWithImage), null);



        public ICommand TappedCommandParameter
        {
            get { return (ICommand)GetValue(TappedCommandParameterProperty); }
            set { SetValue(TappedCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TappedCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TappedCommandParameterProperty =
            BindableProperty.Create("TappedCommandParameter", typeof(ICommand), typeof(LabelWithImage), null);

        

        public ElementPosition ImagePosition
        {
            get { return (ElementPosition)GetValue(ImagePositionProperty); }
            set { SetValue(ImagePositionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImagePosition.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ImagePositionProperty =
            BindableProperty.Create("ImagePosition", typeof(ElementPosition), typeof(LabelWithImage), ElementPosition.Left, propertyChanged: (t, o, n)=>
            {
                var target = t as LabelWithImage;
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
            BindableProperty.Create("LineWidth", typeof(float), typeof(LabelWithImage), 1f);



        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineColor.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty LineColorProperty =
            BindableProperty.Create("LineColor", typeof(Color), typeof(LabelWithImage), Color.Gray);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(LabelWithImage), null);
        
        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty IconProperty =
            BindableProperty.Create("Icon", typeof(ImageSource), typeof(LabelWithImage), null);



        public Thickness ContentMargin
        {
            get { return (Thickness)GetValue(ContentMarginProperty); }
            set { SetValue(ContentMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentMargin.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ContentMarginProperty =
            BindableProperty.Create("ContentMargin", typeof(Thickness), typeof(LabelWithImage), new Thickness());



        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextColor.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(LabelWithImage), Color.Gray);




        public FontAttributes FontAttributes
        {
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
            set { SetValue(FontAttributesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontAttributes.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty FontAttributesProperty =
            BindableProperty.Create("FontAttributes", typeof(FontAttributes), typeof(LabelWithImage), FontAttributes.None);



        public int FontSize
        {
            get { return (int)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontSize.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create("FontSize", typeof(int), typeof(LabelWithImage), -1);

        public NamedSize NamedSize
        {
            get { return (NamedSize)GetValue(NamedSizeProperty); }
            set { SetValue(NamedSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontSize.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty NamedSizeProperty =
            BindableProperty.Create("NamedSize", typeof(NamedSize), typeof(LabelWithImage), NamedSize.Default);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontFamily.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create("FontFamily", typeof(string), typeof(LabelWithImage), default(string));

        public static readonly BindableProperty IconTintColorProperty = BindableProperty.Create(nameof(IconTintColor), typeof(Color), typeof(LabelWithImage), Color.Black);
        
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
            BindableProperty.Create("IconMargin", typeof(Thickness), typeof(LabelWithImage), new Thickness(0));


    }
}
