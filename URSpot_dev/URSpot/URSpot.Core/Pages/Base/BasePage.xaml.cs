using URSpot.Core.Utils;
using URSpot.Core.ViewModels.Base;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace URSpot.Core.Pages.Base
{
    public partial class BasePage : ContentPage, IModalContainerPage
    {
        protected ContentView PART_Modal;

        public BasePage()
        {
            InitializeComponent();
            PART_Modal = this.FindTemplateElementByName<ContentView>("PART_Modal");
            //TODO: Remove the next code 
            //var PART_Error = this.FindTemplateElementByName<Grid>("PART_Error");
            //if (PART_Error != null)
            //{
            //    PART_Error.BindingContext = new ErrorViewModel<object>();
            //    this.BindingContextChanged += (s, e) =>
            //    {
            //        var type = this.BindingContext?.GetType() ?? typeof(object);
            //        var vm = typeof(ErrorViewModel<>).MakeGenericType(type);
            //        PART_Error.BindingContext = Activator.CreateInstance(vm);
            //    };
            //}
        }


        protected override bool OnBackButtonPressed()
        {
            if (this.PART_Modal.IsVisible)
            {
                this.HideModalOverlay();
                return true;
            }
            else
            {
                return base.OnBackButtonPressed();
            }
        }

        public async void HideModalOverlay()
        {
            var completionSource = completionSourceStack.Pop();
            PART_Modal.TranslationY = 0;
            await PART_Modal.TranslateTo(0, this.Height);
            PART_Modal.Content = null;
            PART_Modal.IsVisible = false;
            completionSource.SetResult(true);
            if (NavigationBar.HasValue && !completionSourceStack.Any())
            {
                NavigationPage.SetHasNavigationBar(this, NavigationBar.Value);
                NavigationBar = null;
            }
        }

        Stack<TaskCompletionSource<bool>> completionSourceStack = new Stack<TaskCompletionSource<bool>>();

        public bool IsModalOverlayVisible => completionSourceStack.Any();
        public bool? NavigationBar;
        public Task ShowModalOverlay(View page)
        {
            var completionSource = new TaskCompletionSource<bool>();
            completionSourceStack.Push(completionSource);
            this.RestoreModalOverlay(page);
            return completionSource.Task;
        }

        public void RestoreModalOverlay(View page)
        {
            if(NavigationBar== null)
            {
                NavigationBar = NavigationPage.GetHasNavigationBar(this);
                NavigationPage.SetHasNavigationBar(this, false);
            }
            try
            {
                PART_Modal.Content = page;
                PART_Modal.IsVisible = true;
                PART_Modal.TranslationY = this.Height;
                PART_Modal.TranslateTo(0, 0);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
