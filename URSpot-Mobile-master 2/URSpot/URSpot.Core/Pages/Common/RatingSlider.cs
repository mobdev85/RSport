using URSpot.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace URSpot.Core.Pages.Common
{
    public class RatingSlider : StackLayout
    {
        public RatingSlider()
        {
            this.Spacing = 0;
            this.SizeChanged += RatingSlider_SizeChanged;
        }

        private void RatingSlider_SizeChanged(object sender, EventArgs e)
        {
            this.Children.OfType<TintedImage>().ForEach(_ => _.HeightRequest = this.HeightRequest);
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create("Value", typeof(double), typeof(RatingSlider), 0.0, propertyChanged: (o, ov, nv) => ((RatingSlider)o).InvalidateValue());

        protected TintedImage GetStar(int i )
        {
            return (TintedImage)this.Children[i];
        }
        
        private void InvalidateValue()
        {
            this.InvalidateMaxValue();
            int i = 0;
            var value = Math.Min(this.Value, this.Children.Count);
            var integerValue = (int)Math.Floor(value);
            var decimals = value - integerValue;
            for (;i< integerValue;i++)
            {
                this.GetStar(i).Source = this.FullStar;
            }

            if (i == this.Children.Count) return;
            if(decimals <= double.Epsilon)
            {
                this.GetStar(i).Source = this.EmptyStar;
            }
            else if(decimals <= 0.25)
            {
                this.GetStar(i).Source = this.QuarterStar ?? this.HalfStar;
            }
            else if(decimals <= 0.5)
            {
                this.GetStar(i).Source = this.HalfStar;
            }
            else if (decimals <= 0.75)
            {
                this.GetStar(i).Source = this.ThreeQuarterStar ?? this.FullStar;
            }

            for(i++; i< this.Children.Count;i++)
            {
                this.GetStar(i).Source = this.EmptyStar;
            }
        }

        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty MaxValueProperty =
            BindableProperty.Create("MaxValue", typeof(int), typeof(RatingSlider), 0, propertyChanged: (o,n,v)=> ((RatingSlider)o).InvalidateMaxValue());

        private void InvalidateMaxValue()
        {
            if (this.Children.Count == this.MaxValue) return;

            for(int i = this.MaxValue; i< this.Children.Count;i++)
            {
                this.Children.RemoveAt(this.MaxValue);
            }

            for (int i = this.Children.Count; i < this.MaxValue; i++)
            {
                var image = new TintedImage { HeightRequest = this.HeightRequest };
                this.AddImageGestures(i, image);
                this.Children.Add(image);
            }
            this.InvalidateValue();
        }
        void AddImageGestures(int index, TintedImage image)
        {
            if (this.IsReadonly) return;

            image.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => this.Value = index + 1)
            });
        }
        

        public bool IsReadonly
        {
            get { return (bool)GetValue(IsReadonlyProperty); }
            set { SetValue(IsReadonlyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsReadonly.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty IsReadonlyProperty =
            BindableProperty.Create("IsReadonly", typeof(bool), typeof(RatingSlider), true, propertyChanged: (o, ov, nv) =>
        {
            ((RatingSlider)o).Children.OfType<TintedImage>().ForEach((img, i) => ((RatingSlider)o).AddImageGestures(i, img));
        });



        public ImageSource EmptyStar
        {
            get { return (ImageSource)GetValue(EmptyStarProperty); }
            set { SetValue(EmptyStarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EmptyStar.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty EmptyStarProperty =
            BindableProperty.Create("EmptyStar", typeof(ImageSource), typeof(RatingSlider), null, propertyChanged: (o, ov, nv) => ((RatingSlider)o).InvalidateValue());



        public ImageSource QuarterStar
        {
            get { return (ImageSource)GetValue(QuarterStarProperty); }
            set { SetValue(QuarterStarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for QuarterStar.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty QuarterStarProperty =
            BindableProperty.Create("QuarterStar", typeof(ImageSource), typeof(RatingSlider), null, propertyChanged: (o, ov, nv) => ((RatingSlider)o).InvalidateValue());
        

        public ImageSource HalfStar
        {
            get { return (ImageSource)GetValue(HalfStarProperty); }
            set { SetValue(HalfStarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HalfStar.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty HalfStarProperty =
            BindableProperty.Create("HalfStar", typeof(ImageSource), typeof(RatingSlider), null, propertyChanged: (o, ov, nv) => ((RatingSlider)o).InvalidateValue());

        
        public ImageSource ThreeQuarterStar
        {
            get { return (ImageSource)GetValue(ThreeQuarterStarProperty); }
            set { SetValue(ThreeQuarterStarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ThreeQuarterStar.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ThreeQuarterStarProperty =
            BindableProperty.Create("ThreeQuarterStar", typeof(ImageSource), typeof(RatingSlider), null, propertyChanged: (o, ov, nv) => ((RatingSlider)o).InvalidateValue());



        public ImageSource FullStar
        {
            get { return (ImageSource)GetValue(FullStarProperty); }
            set { SetValue(FullStarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FullStar.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty FullStarProperty =
            BindableProperty.Create("FullStar", typeof(ImageSource), typeof(RatingSlider), null, propertyChanged: (o, ov, nv) => ((RatingSlider)o).InvalidateValue());




        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TintColor.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty TintColorProperty =
            BindableProperty.Create("TintColor", typeof(Color), typeof(RatingSlider), Color.Transparent, propertyChanged: (o, ov, nv) =>
            {
                ((RatingSlider)o)
                    .Children
                    .OfType<TintedImage>()
                    .ForEach(_ => _.TintColor = (Color)nv);
            });



    }
}
