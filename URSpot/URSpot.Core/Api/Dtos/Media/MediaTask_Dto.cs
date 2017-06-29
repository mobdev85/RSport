using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Api.Dtos.Media
{
    public class MediaTask_Dto
    {
        public long Id { get; set; }
        public string Filename { get; set; }
        public long? PlaceId { get; set; }
        public long? UserId { get; set; }
        public string Url { get; set; }
        public int Size { get; set; }
        public long TypeId { get; set; }
        public Guid UuId { get; set; }
    }
}
