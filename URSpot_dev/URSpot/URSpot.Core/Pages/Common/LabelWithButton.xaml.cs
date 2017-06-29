using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace URSpot.Core.Pages.Common
{
    public partial class LabelWithButton : ContentView
    {
        public LabelWithButton()
        {
            InitializeComponent();
            PART_Button.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    this.ButtonTapped?.Invoke(this, EventArgs.Empty);
                    var cmd = this.ButtonTappedCommand ?? this.TappedCommand;
                    if (cmd?.CanExecute(this.ButtonTappedCommandParameter) ?? false)
                    {
                        cmd?.Execute(this.ButtonTappedCommandParameter);
                    }
                },
                () => this.ButtonTapped != null || this.ButtonTappedCommand != null || this.TappedCommand != null)
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

        event EventHandler ButtonTapped;


        public ICommand ButtonTappedCommand
        {
            get { return (ICommand)GetValue(ButtonTappedCommandProperty); }
            set { SetValue(ButtonTappedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonTappedCommand.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ButtonTappedCommandProperty =
            BindableProperty.Create("ButtonTappedCommand", typeof(ICommand), typeof(LabelWithButton), null);


        public object ButtonTappedCommandParameter
        {
            get { return (object)GetValue(ButtonTappedCommandParameterProperty); }
            set { SetValue(ButtonTappedCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonTappedCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ButtonTappedCommandParameterProperty =
            BindableProperty.Create("ButtonTappedCommandParameter", typeof(object), typeof(LabelWithButton), null);

        public ICommand TappedCommand
        {
            get { return (ICommand)GetValue(TappedCommandProperty); }
            set { SetValue(TappedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TappedCommand.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TappedCommandProperty =
            BindableProperty.Create("TappedCommand", typeof(ICommand), typeof(LabelWithButton), null);



        public ICommand TappedCommandParameter
        {
            get { return (ICommand)GetValue(TappedCommandParameterProperty); }
            set { SetValue(TappedCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TappedCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TappedCommandParameterProperty =
            BindableProperty.Create("TappedCommandParameter", typeof(ICommand), typeof(LabelWithButton), null);



        public ElementPosition ButtonPosition
        {
            get { return (ElementPosition)GetValue(ButtonPositionProperty); }
            set { SetValue(ButtonPositionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImagePosition.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ButtonPositionProperty =
            BindableProperty.Create("ButtonPosition", typeof(ElementPosition), typeof(LabelWithButton), ElementPosition.Left, propertyChanged: (t, o, n) =>
            {
                var target = t as LabelWithButton;
                var pos = (int)(ElementPosition)n;
                if ((pos & 4) != 0)
                {
                    Grid.SetRow(target.PART_Button, pos & 3);
                    Grid.SetColumn(target.PART_Button, 1);
                }
                else
                {
                    Grid.SetRow(target.PART_Button, 1);
                    Grid.SetColumn(target.PART_Button, pos);
                }
            });


        public float LineWidth
        {
            get { return (float)GetValue(LineWidthProperty); }
            set { SetValue(LineWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineWidth.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty LineWidthProperty =
            BindableProperty.Create("LineWidth", typeof(float), typeof(LabelWithButton), 1f);



        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineColor.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty LineColorProperty =
            BindableProperty.Create("LineColor", typeof(Color), typeof(LabelWithButton), Color.Gray);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(LabelWithButton), null);

        public string TextButton
        {
            get { return (string)GetValue(TextButtonProperty); }
            set { SetValue(TextButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TextButtonProperty =
            BindableProperty.Create("TextButton", typeof(string), typeof(LabelWithButton), null);

        public Thickness ContentMargin
        {
            get { return (Thickness)GetValue(ContentMarginProperty); }
            set { SetValue(ContentMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentMargin.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ContentMarginProperty =
            BindableProperty.Create("ContentMargin", typeof(Thickness), typeof(LabelWithButton), new Thickness());



        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextColor.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(LabelWithButton), Color.Black);


        public Color TextButtonColor
        {
            get { return (Color)GetValue(TextButtonColorProperty); }
            set { SetValue(TextButtonColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextColor.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TextButtonColorProperty =
            BindableProperty.Create("TextButtonColor", typeof(Color), typeof(LabelWithButton), Color.FromHex("#aa80ff"));

        public FontAttributes FontAttributes
        {
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
            set { SetValue(FontAttributesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontAttributes.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty FontAttributesProperty =
            BindableProperty.Create("FontAttributes", typeof(FontAttributes), typeof(LabelWithButton), FontAttributes.None);


        public int FontSize
        {
            get { return (int)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontSize.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create("FontSize", typeof(int), typeof(LabelWithButton), -1);

        public NamedSize NamedSize
        {
            get { return (NamedSize)GetValue(NamedSizeProperty); }
            set { SetValue(NamedSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontSize.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty NamedSizeProperty =
            BindableProperty.Create("NamedSize", typeof(NamedSize), typeof(LabelWithButton), NamedSize.Default);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontFamily.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create("FontFamily", typeof(string), typeof(LabelWithButton), default(string));


        public Thickness ButtonMargin
        {
            get { return (Thickness)GetValue(ButtonMarginProperty); }
            set { SetValue(ButtonMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconMargin.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ButtonMarginProperty =
            BindableProperty.Create("ButtonMargin", typeof(Thickness), typeof(LabelWithButton), new Thickness(0));
    }
}