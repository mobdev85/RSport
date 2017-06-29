using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.Dtos.Auth;
using URSpot.Core.Api.Dtos.User;
using URSpot.Core.Models.User;

namespace URSpot.Core.Api.Mappings
{
    public static class ModelToDto
    {
      
        public static Req_FormRegister_Dto ToDto(this UserModel data)
        {
            Req_FormRegister_Dto result = new Req_FormRegister_Dto()
            {
                
            };
            return result;
        }

        public static UserProfile_Dto ToProfileDto(this UserModel data)
        {
            UserProfile_Dto result = new UserProfile_Dto()
            {

            };
            return result;
        }
    }
}
