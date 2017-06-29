using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.BusinessRules;

namespace URSpot.Core.Api.Dtos.Friend
{
    public class InAppUser_Dto
    {
        public string DisplayImageUrl { get; set; }

        public string Email { get; set; }

        public string FistName { get; set; }

        public bool IsFriend { get; set; }

        public bool IsFriendRequestSent { get; set; }

        public long Id { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public FriendRules Rules { get; set; }
    }
}
