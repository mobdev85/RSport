using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace URSpot.Core.Behaviors
{
    /// <summary>
    /// https://github.com/PlainConcepts/MobilityDay/tree/9241044556e0bde3e89b9281304922df6e4d28eb/Xamarin%20Demos/Demos/MobilityDay.Forms/MobilityDay/Views
    /// </summary>
    public class ItemTappedCommandListView
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.CreateAttached("ItemTappedCommand", typeof(ICommand), typeof(ItemTappedCommandListView), default(ICommand), BindingMode.OneWay, propertyChanged: PropertyChanged);

        private static void PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ListView listView)
            {
                listView.ItemTapped += ListViewOnItemTapped;
            }
        }

        private static void ListViewOnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView list)
            {
                list.SelectedItem = null;
                var command = GetItemTappedCommand(list);
                if (command != null && command.CanExecute(e.Item))
                {
                    command.Execute(e.Item);
                }
            }
        }

        public static ICommand GetItemTappedCommand(BindableObject bindableObject)
        {
            return (ICommand)bindableObject.GetValue(ItemTappedCommandProperty);
        }

        public static void SetItemTappedCommand(BindableObject bindableObject, object value)
        {
            bindableObject.SetValue(ItemTappedCommandProperty, value);
        }
    }
}
