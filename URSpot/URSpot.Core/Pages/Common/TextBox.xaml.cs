using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace URSpot.Core.Pages.Common
{
    public enum ElementPosition
    {
        Left = 0,
        Right = 2,
        Top = 4, //0b100
        Bottom = 6, //0b110
    }
    public partial class TextBox : ContentView
    {
        public TextBox()
        {
            InitializeComponent();
            PART_Image.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    this.IconTapped?.Invoke(this, EventArgs.Empty);
                    var cmd = this.IconTappedCommand;
                    if (cmd?.CanExecute(this.IconTappedCommandParameter) ?? false)
                    {
                        cmd?.Execute(this.IconTappedCommandParameter);
                    }
                })
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
            BindableProperty.Create("IconTappedCommand", typeof(ICommand), typeof(TextBox), null);




        public object IconTappedCommandParameter
        {
            get { return (object)GetValue(IconTappedCommandParameterProperty); }
            set { SetValue(IconTappedCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconTappedCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty IconTappedCommandParameterProperty =
            BindableProperty.Create("IconTappedCommandParameter", typeof(object), typeof(TextBox), null);



        public ElementPosition ImagePosition
        {
            get { return (ElementPosition)GetValue(ImagePositionProperty); }
            set { SetValue(ImagePositionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImagePosition.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ImagePositionProperty =
            BindableProperty.Create("ImagePosition", typeof(ElementPosition), typeof(TextBox), ElementPosition.Left, propertyChanged: (t, o, n) =>
            {
                var target = t as TextBox;
                Grid.SetColumn(target.PART_Image, (int)(ElementPosition)n);
            });


        public float LineWidth
        {
            get { return (float)GetValue(LineWidthProperty); }
            set { SetValue(LineWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineWidth.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty LineWidthProperty =
            BindableProperty.Create("LineWidth", typeof(float), typeof(TextBox), 1f);



        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineColor.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty LineColorProperty =
            BindableProperty.Create("LineColor", typeof(Color), typeof(TextBox), Color.White);



        public float FocusedLineWidth
        {
            get { return (float)GetValue(FocusedLineWidthProperty); }
            set { SetValue(FocusedLineWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FocusedLineWidth.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty FocusedLineWidthProperty =
            BindableProperty.Create("FocusedLineWidth", typeof(float), typeof(TextBox), 1f);




        public Color FocusedLineColor
        {
            get { return (Color)GetValue(FocusedLineColorProperty); }
            set { SetValue(FocusedLineColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FocusedLineColor.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty FocusedLineColorProperty =
            BindableProperty.Create("FocusedLineColor", typeof(Color), typeof(TextBox), Color.DeepSkyBlue);


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(TextBox), null, BindingMode.TwoWay);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextColor.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(LabelWithImage), Color.White);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Placeholder.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create("Placeholder", typeof(string), typeof(TextBox), null);



        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Keyboard.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create("Keyboard", typeof(Keyboard), typeof(TextBox), Keyboard.Default);

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPassword.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create("IsPassword", typeof(bool), typeof(TextBox), false);

        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty IconProperty =
            BindableProperty.Create("Icon", typeof(ImageSource), typeof(TextBox), null);


        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineColor.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create("MaxLength", typeof(int), typeof(Entry), 0);

        public static readonly BindableProperty TintColorProperty = BindableProperty.Create(nameof(IconTintColor), typeof(Color), typeof(TextBox), Color.White);

        public Color IconTintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }

        public int FontSize
        {
            get { return (int)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontSize.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create("FontSize", typeof(int), typeof(LabelWithImage), 15);
        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontFamily.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create("FontFamily", typeof(string), typeof(LabelWithImage), default(string));

        public FontAttributes FontAttributes
        {
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
            set { SetValue(FontAttributesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontAttributes.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty FontAttributesProperty =
            BindableProperty.Create("FontAttributes", typeof(FontAttributes), typeof(LabelWithImage), FontAttributes.None);

    }
}
