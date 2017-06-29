using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace URSpot.Core.Pages.Common
{
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }
            return ImageSourceFromResource(Source);
        }

        static Assembly assembly = typeof(ImageResourceExtension).GetTypeInfo().Assembly;
        public static ImageSource ImageSourceFromResource(string name)
        {
            byte[] buffer;
            using (Stream s = assembly.GetManifestResourceStream("URSpot.Core.Images." + name.Replace("/", ".").Replace("*", "@2x")))
            {
                long length = s.Length;
                buffer = new byte[length];
                s.Read(buffer, 0, (int)length);
            }

            // Do your translation lookup here, using whatever method you require
            var imageSource = new StreamImageSource { Stream = (c) => Task.FromResult((Stream)new MemoryStream(buffer)) };
            return imageSource;
        }
    }
}
