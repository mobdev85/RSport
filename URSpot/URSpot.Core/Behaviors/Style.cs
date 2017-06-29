using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace URSpot.Core.Behaviors
{
    public class Style
    {
        public static string GetKeyFormat(BindableObject obj)
        {
            return (string)obj.GetValue(KeyFormatProperty);
        }

        public static void SetKeyFormat(BindableObject obj, string value)
        {
            obj.SetValue(KeyFormatProperty, value);
        }

        // Using a DependencyProperty as the backing store for KeyFormat.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty KeyFormatProperty =
            BindableProperty.Create("KeyFormat", typeof(string), typeof(Style), "{0}");


        public static string GetKey(BindableObject obj)
        {
            return (string)obj.GetValue(KeyProperty);
        }

        public static void SetKey(BindableObject obj, string value)
        {
            obj.SetValue(KeyProperty, value);
        }

        // Using a DependencyProperty as the backing store for Key.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty KeyProperty =
            BindableProperty.Create("Key", typeof(string), typeof(Style), null, propertyChanged: (target, oldValue, newValue) =>
            {
                object style = null;
                var element = target as Element;
                var key = string.Format(GetKeyFormat(target) ?? "{0}", newValue);
                while (element != null)
                {
                    if((element as VisualElement)?.Resources?.TryGetValue(key, out style) ?? false)
                    {
                        break;
                    }
                    element = element.Parent;
                }

                if (style == null && Application.Current != null && Application.Current.Resources != null)
                {
                    Application.Current.Resources.TryGetValue(key, out style);
                }

                if (style != null)
                {
                    (target as VisualElement).Style = (Xamarin.Forms.Style)style;
                }
            });
    }
}
