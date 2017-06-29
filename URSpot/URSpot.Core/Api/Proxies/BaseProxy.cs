using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.Dtos.Auth;
using URSpot.Core.Statics;

namespace URSpot.Core.Api.Proxies
{
    public interface IBaseProxy
    {
        

    }

    public class BaseProxy : IBaseProxy
    {
        protected URSpotWebClientApi ClientApi;

        //@todo: this will be populated from Resources files
        protected readonly static string INVALID_DATA = "Invalid data";
        protected readonly static string NO_INTERNET_CONNECTION = "No Internet connection";
        protected readonly static string INTERNAL_ERROR = "Internal Error";

        public BaseProxy()
        {
            this.ClientApi = new URSpotWebClientApi(WebApi.Baseurl);
        }
    }
}
