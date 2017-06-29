using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Models;
using URSpot.Core.Services;
using URSpot.Core.Utils;
using URSpot.Core.ViewModels.Base;
using Xamarin.Forms;

namespace URSpot.Core.ViewModels.Account
{
    public class FacebookLoginViewModel : BaseViewModel
    { 
        /// Make sure to get a new ClientId from:
        /// https://developers.facebook.com/apps/
        /// </summary>
        private string ClientId = "165942640479284";
        public FacebookLoginViewModel()
        {
            var apiRequest =
            "https://www.facebook.com/dialog/oauth?client_id="
            + ClientId
            + "&display=popup&response_type=token&redirect_uri=http://www.facebook.com/connect/login_success.html";

            GatewayPageSource = apiRequest;
        }

        private WebViewSource _GateWaySource;
        public WebViewSource GatewayPageSource
        {
            get { return _GateWaySource; }
            set
            {
                SetProperty(ref _GateWaySource, value);
            }
        }

        private void ExecuteShowEditAbout(object obj)
        {
           ShowViewModel<SignUpStartViewModel>(); 
        }

        //public MvxCommand WebViewNavigatedCommand(object sender, WebNavigatedEventArgs e)
        //{

        //    return new MvxCommand(() => WebViewOnNavigated(sender, e));

        //}

        FacebookViewModel _Filters;
        public FacebookViewModel Filters
        {
            get { return _Filters; }
            set { SetProperty(ref this._Filters, value); }
        }

        //private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        //{

        //    var accessToken = ExtractAccessTokenFromUrl(e.Url);

        //    if (accessToken != "")
        //    {
        //        var vm = new FacebookViewModel();

        //        await vm.SetFacebookUserProfileAsync(accessToken);
        //        this.Filters = vm;
        //    }
        //}

        //private string ExtractAccessTokenFromUrl(string url)
        //{
        //    if (url.Contains("access_token") && url.Contains("&expires_in="))
        //    {
        //        var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

        //        if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.WinPhone || Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.WinPhone)
        //        {
        //            at = url.Replace("http://www.facebook.com/connect/login_success.html#access_token=", "");
        //        }

        //        var accessToken = at.Remove(at.IndexOf("&expires_in="));

        //        return accessToken;
        //    }

        //    return string.Empty;
        //}
    }
}
