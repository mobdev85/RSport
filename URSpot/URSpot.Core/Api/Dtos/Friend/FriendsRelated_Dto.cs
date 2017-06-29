using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Api.Dtos.Friend
{
    public class FriendsRelated_Dto
    {
        public List<Friend_Dto> Friends { get; set; }
        public List<InAppUser_Dto> Suggestions { get; set; }
        public List<Friend_Dto> FriendRequests { get; set; }
    }
}
