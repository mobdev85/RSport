using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Api.Dtos.Auth
{
    public class Req_FormLogin_Dto
    {
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
