using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Statics;

namespace URSpot.Core.Models.User
{
    public class UserModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public Enums.Gender Gender { get; set; }
        public long? FavoriteMusicId { get; set; }
        public long? FavoriteSportId { get; set; }
        public bool ShareLocation { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        public string FavoriteMusicName { get; set; }
        public string FavoriteSportName { get; set; }

    }
}
