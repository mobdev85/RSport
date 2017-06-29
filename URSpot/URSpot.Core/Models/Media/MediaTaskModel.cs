using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Models.Media
{
    public class MediaTaskModel : BaseModel
    {
        public string Filename { get; set; }
        public long? VenueId { get; set; }
        public long? UserId { get; set; }
        public string Url { get; set; }
        public int Size { get; set; }
        public long TypeId { get; set; }
        public Guid UuId { get; set; }
    }
}
