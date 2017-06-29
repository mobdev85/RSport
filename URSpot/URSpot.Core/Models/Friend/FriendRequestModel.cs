using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Models.Rules;

namespace URSpot.Core.Models.Friend
{
    public class FriendRequestModel : BaseModel
    {
        public FriendRulesModel Rules { get; set; }
    }
}
