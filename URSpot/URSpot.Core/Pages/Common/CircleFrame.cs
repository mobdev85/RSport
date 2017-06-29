using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace URSpot.Core.Pages.Common
{ /// <summary>
  /// CircleFrame Interface
  /// </summary>
    public class CircleFrame : Frame
    {
        /// <summary>
        /// Thickness property of border
        /// </summary>
        public static readonly BindableProperty BorderThicknessProperty = BindableProperty.Create("BorderThickness", typeof(int), typeof(Frame), 0);

        /// <summary>
        /// Border thickness of circle image
        /// </summary>
        public int BorderThickness
        {
            get { return (int)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        /// <summary>
        /// Color property of border
        /// </summary>
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create("BorderColor", typeof(Color), typeof(Frame), Color.White);
        /// <summary>
        /// Border Color of circle image
        /// </summary>
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }


        /// <summary>
        /// BorderRadius of circle image
        /// </summary>
        public int BorderRadius
        {
            get { return (int)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }

        /// <summary>
        /// Color property of border
        /// </summary>
        public static readonly BindableProperty BorderRadiusProperty = BindableProperty.Create("BorderRadius", typeof(Int32), typeof(Frame), 0);

        /// <summary>
        /// FrameWitdh of circle image
        /// </summary>
        public int FrameWidth
        {
            get { return (int)GetValue(FrameWidthProperty); }
            set { SetValue(FrameWidthProperty, value); }
        }

        /// <summary>
        /// Color property of border
        /// </summary>
        public static readonly BindableProperty FrameWidthProperty = BindableProperty.Create("FrameWidth", typeof(Int32), typeof(Frame), 0);


        /// <summary>
        /// FrameWitdh of circle image
        /// </summary>
        public int FrameHeight
        {
            get { return (int)GetValue(FrameHeightProperty); }
            set { SetValue(FrameHeightProperty, value); }
        }

        /// <summary>
        /// Color property of border
        /// </summary>
        public static readonly BindableProperty FrameHeightProperty = BindableProperty.Create("FrameHeight", typeof(Int32), typeof(Frame), 0);
    }
}
