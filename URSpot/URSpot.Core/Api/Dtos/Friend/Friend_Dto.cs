using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.BusinessRules;
using URSpot.Core.Api.Dtos.Misc;

namespace URSpot.Core.Api.Dtos.Friend
{
    public class Friend_Dto
    {
        public long Id { get; set; }
        public long FromId { get; set; }
        public long ToId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address_Dto LastLocation { get; set; }
        public string DisplayImageUrl { get; set; }
        public double? DistanceToLastLocation { get; set; }
        public FriendRules Rules { get; set; }
    }
}
