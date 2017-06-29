using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace URSpot.Core.Pages.Base
{
    interface IModalContainerPage
    {
        Task ShowModalOverlay(View page);
        void RestoreModalOverlay(View page);
        void HideModalOverlay();

        bool IsModalOverlayVisible { get; }

    }
}
