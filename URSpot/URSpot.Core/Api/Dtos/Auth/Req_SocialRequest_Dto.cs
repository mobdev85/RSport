using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Api.Dtos.Auth
{
    public class Req_SocialRequest_Dto
    {
        public string AccessToken { get; set; }
        public string Provider { get; set; }
    }
}
