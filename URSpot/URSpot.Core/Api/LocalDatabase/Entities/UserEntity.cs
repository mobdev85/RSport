using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Api.LocalDatabase.Entities
{
    public class UserEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public bool IsMale { get; set; }
        public bool IsOtherGender { get; set; }
        public bool IsLocationVisible { get; set; }
        public string DisplayImageUrl { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public long? FavoriteMusicId { get; set; }
        public long? FavoriteSportId { get; set; }

        public long UserId { get; set; }
        public string AuthToken { get; set; }
        public string Phone { get; set; }
    }
}
