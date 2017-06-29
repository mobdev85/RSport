using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Api.BusinessRules
{
    public class FriendRules
    {
        public bool CanInviteToUseApp { get; set; }
        public bool CanSendFriendRequest { get; set; }
        public bool CanAcceptFriendRequest { get; set; }
        public bool CanRejectFriendRequest { get; set; }
    }
}
