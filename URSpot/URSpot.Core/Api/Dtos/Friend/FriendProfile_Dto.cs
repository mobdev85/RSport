using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.BusinessRules;
using URSpot.Core.Api.Dtos.Misc;

namespace URSpot.Core.Api.Dtos.Friend
{
    public class FriendProfile_Dto
    {
        public string DisplayImageUrl { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public long Id { get; set; }

        public string LastName { get; set; }

        public Address_Dto LastPlace { get; set; }

        public string PhoneNumber { get; set; }

        public FriendRules Rules { get; set; }
    }
}
