using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.BusinessRules;

namespace URSpot.Core.Api.Dtos.Friend
{
    public  class FriendRequest_Dto
    {
        public string Code { get; set; }

        public DateTime CreatedOn { get; set; }

        public long FromId { get; set; }

        public long Id { get; set; }

        public string Message { get; set; }

        public long StatusId { get; set; }

        public long ToId { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayImageUrl { get; set; }

        public FriendRules Rules { get; set; }
    }
}
