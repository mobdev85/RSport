using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.LocalDatabase;
using URSpot.Core.Statics;
using Xamarin.Forms;

namespace URSpot.Core.Api
{
    public class URSpotWebClientApi : BaseClientApi
    {
        public URSpotWebClientApi(string baseUrl) : base(baseUrl)
        {
        }

        protected override void PrepareAuthorizeData()
        {
            var userRepository = DependencyService.Get<IUserRepository>();
            var currentUser = userRepository.GetUser();
            string headerAuthValue = WebApi.HeaderAuthValue;

            if (currentUser != null)
            {
                headerAuthValue = string.Format("{0}:{1}", currentUser.UserId, currentUser.AuthToken);
            }
            if (Client.DefaultRequestHeaders.Contains(WebApi.HeaderAuthKey))
            {
                Client.DefaultRequestHeaders.Remove(WebApi.HeaderAuthKey);
            }
            Client.DefaultRequestHeaders.Add(WebApi.HeaderAuthKey, headerAuthValue);
        }
    }
}
