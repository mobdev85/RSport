using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace URSpot.Core.Behaviors
{
    public class NoSelection : BaseBehavior<ListView>
    {
        protected override void OnAttachedTo(ListView bindable)
        {
            bindable.ItemTapped += OnItemTapped;
            base.OnAttachedTo(bindable);
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            this.AssociatedObject.SelectedItem = null;
        }
        protected override void OnDetachingFrom(ListView bindable)
        {
            bindable.ItemTapped -= OnItemTapped;
            base.OnDetachingFrom(bindable);
        }
    }
}
