using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.Dtos.User;

namespace URSpot.Core.Api.Dtos.Auth
{
    public class Resp_Login_Dto : UserProfile_Dto
    {
        public string Token { get; set; }
    }
}
