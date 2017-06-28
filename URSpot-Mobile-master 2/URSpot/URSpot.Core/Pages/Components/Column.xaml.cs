using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace URSpot.Core.Pages.Components
{


    public partial class Column : ContentView
    {

		
        public Column()
        {
            InitializeComponent();

			ColumnFrame.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() =>
				{
					this.ColumnTapped?.Invoke(this, EventArgs.Empty);
					var cmd = this.ColumnTappedCommand ?? this.TappedCommand;
					if (cmd?.CanExecute(this.ColumnTappedCommandParameter) ?? false)
					{
						cmd?.Execute(this.ColumnTappedCommandParameter);
					}
				},
				() => this.ColumnTapped != null || this.ColumnTappedCommand != null || this.TappedCommand != null)
			});

        }


        event EventHandler ColumnTapped;

		public ICommand ColumnTappedCommand
		{
			get { return (ICommand)GetValue(ColumnTappedCommandProperty); }
			set { SetValue(ColumnTappedCommandProperty, value); }
		}

		// Using a DependencyProperty as the backing store for ColumnTappedCommand.  This enables animation, styling, binding, etc...
		public static readonly BindableProperty ColumnTappedCommandProperty =
            BindableProperty.Create("ColumnTappedCommand", typeof(ICommand), typeof(Column), null);


		public object ColumnTappedCommandParameter
		{
			get { return (object)GetValue(ColumnTappedCommandParameterProperty); }
			set { SetValue(ColumnTappedCommandParameterProperty, value); }
		}

		// Using a DependencyProperty as the backing store for ColumnTappedCommandParameter.  This enables animation, styling, binding, etc...
		public static readonly BindableProperty ColumnTappedCommandParameterProperty =
            BindableProperty.Create("ColumnTappedCommandParameter", typeof(object), typeof(Column), null);



		public ICommand TappedCommand
		{
			get { return (ICommand)GetValue(TappedCommandProperty); }
			set { SetValue(TappedCommandProperty, value); }
		}

		// Using a DependencyProperty as the backing store for TappedCommand.  This enables animation, styling, binding, etc...
		public static readonly BindableProperty TappedCommandProperty =
            BindableProperty.Create("TappedCommand", typeof(ICommand), typeof(Column), null);



		public ImageSource ImageSrc
		{
			get { return (ImageSource)GetValue(ImageSrcProperty); }
			set { SetValue(ImageSrcProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
		public static readonly BindableProperty ImageSrcProperty =
            BindableProperty.Create("ImageSrc", typeof(ImageSource), typeof(Column), null);




		public String LabelTxt
		{
			get { return (String)GetValue(LabelTxtProperty); }
			set { SetValue(LabelTxtProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
		public static readonly BindableProperty LabelTxtProperty =
			BindableProperty.Create("LabelTxt", typeof(String), typeof(Column), null);





		public String GestureName
		{
			get { return (String)GetValue(GestureNameProperty); }
			set { SetValue(GestureNameProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
		public static readonly BindableProperty GestureNameProperty =
			BindableProperty.Create("GestureName", typeof(String), typeof(Column), null);


	}

}
