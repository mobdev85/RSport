using URSpot.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace URSpot.Core.Behaviors
{
    public class Tapped
    {
        public static ICommand GetCommand(BindableObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }

        public static void SetCommand(BindableObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }
        

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(Tapped), null, propertyChanged: OnCommandChanged);
        
        private static void OnCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var target = (View)bindable;
            if(oldValue != null)
            {
                for(int i =0;i<target.GestureRecognizers.Count;i++)
                {
                    if((target.GestureRecognizers[i] as TapGestureRecognizer)?.Command ==  oldValue)
                    {
                        target.GestureRecognizers.RemoveAt(i);
                        break;
                    }
                }
            }
            if (newValue != null)
            {
                target.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = (ICommand)newValue,
                    CommandParameter = GetCommandParameter(bindable)
                });
            }
        }

        public static object GetCommandParameter(BindableObject obj)
        {
            return (object)obj.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(BindableObject obj, object value)
        {
            obj.SetValue(CommandParameterProperty, value);
        }


        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(Tapped), null, propertyChanged: OnCommandParameterChanged);

        private static void OnCommandParameterChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var target = (View)bindable;
            var cmd = GetCommand(bindable);
            target.GestureRecognizers
                .OfType<TapGestureRecognizer>()
                .Where(_ => _.Command == cmd)
                .ForEach(_ => _.CommandParameter = newValue);
        }
    }
}
