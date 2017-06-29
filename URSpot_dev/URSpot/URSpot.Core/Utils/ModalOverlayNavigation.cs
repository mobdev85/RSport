using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Pages.Base;
using Xamarin.Forms;

namespace URSpot.Core.Utils
{
    public class ModalOverlayNavigation
    {
        Stack<View> overlays = new Stack<View>();
        public Task<TViewModel> ShowModalOverlay<TViewModel>(Action<TViewModel> init = null)
        {
            var request = MvxViewModelRequest.GetDefaultRequest(typeof(TViewModel));
            var vm = (TViewModel)Mvx.Resolve<IMvxViewModelLoader>().LoadViewModel(request, null);
            init?.Invoke(vm);
            return ShowModalOverlay(vm);
        }
        public async Task<TViewModel> ShowModalOverlay<TViewModel>(TViewModel viewModel)
        {
            var pageType = GetPageType(viewModel.GetType());
            var page = Activator.CreateInstance(pageType) as View;
            var mainPage = Application.Current.MainPage as NavigationPage;
            var modalContainer = mainPage.CurrentPage as IModalContainerPage;
            //var modalTabContainer = mainPage.CurrentPage as TabbedPage;
            //if (modalContainer== null && modalTabContainer != null)
            //    modalContainer = modalTabContainer.CurrentPage as IModalContainerPage;

            page.BindingContext = viewModel;
            using (new SimpleDisposable(this.RestorPreviousOverlay))
            {
                overlays.Push(page);
                await modalContainer.ShowModalOverlay(page);
            }
            return viewModel;
        }

        private void RestorPreviousOverlay()
        {
            overlays.Pop();
            var prevOverlay = overlays.Count > 0 ? overlays.Peek() : null;
            if (prevOverlay != null)
            {
                var mainPage = Application.Current.MainPage as NavigationPage;
                var modalContainer = mainPage.CurrentPage as IModalContainerPage;
                modalContainer.RestoreModalOverlay(prevOverlay);
            }
        }

        public void HideModalOverlay()
        {
            var mainPage = Application.Current.MainPage as NavigationPage;
            var modalContainer = mainPage.CurrentPage as IModalContainerPage;
            //var modalTabContainer = mainPage.CurrentPage as TabbedPage;
            //if (modalContainer == null && modalTabContainer != null)
            //    modalContainer = modalTabContainer.CurrentPage as IModalContainerPage;
            modalContainer.HideModalOverlay();
        }

        protected virtual string GetPageName(Type vmType)
        {
            var viewModelName = vmType.Name;
            return viewModelName.Replace("ViewModel", "Page");
        }
        IMvxViewsContainer _viewFinder;
        protected virtual Type GetPageType(Type vmType)
        {
            if (_viewFinder == null)
                _viewFinder = Mvx.Resolve<IMvxViewsContainer>();

            try
            {
                return _viewFinder.GetViewType(vmType);
            }
            catch (KeyNotFoundException)
            {
                var pageName = GetPageName(vmType);
                return vmType.GetTypeInfo().Assembly.CreatableTypes()
                    .FirstOrDefault(t => t.Name == pageName);
            }
        }
    }
    public static class ModalOverlayNavigationExt
    {
        public static Task<TViewModel> ShowModalOverlay<TViewModel>(this MvxViewModel @this, Action<TViewModel> init = null)
        {
            return Mvx.Resolve<ModalOverlayNavigation>().ShowModalOverlay(init);
        }
        public static Task<TViewModel> ShowModalOverlay<TViewModel>(this MvxViewModel @this, TViewModel viewModel)
        {
            return Mvx.Resolve<ModalOverlayNavigation>().ShowModalOverlay(viewModel);
        }


        public static void DismissCurrentModalOverlay(this MvxViewModel @this)
        {
            Mvx.Resolve<ModalOverlayNavigation>().HideModalOverlay();
        }
    }
}
