using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.ViewModels
{
    public interface INavigationAwareViewModel
    {
        void OnActivated();
        void OnDeactivated();
        event EventHandler Activated;
        event EventHandler Deactivated;
    }
}
