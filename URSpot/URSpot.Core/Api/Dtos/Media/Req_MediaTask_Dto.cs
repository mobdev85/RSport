using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Api.Dtos.Media
{
    public class Req_MediaTask_Dto
    {
        public string Filename { get; set; }
        public int Size { get; set; }
        public long? PlaceId { get; set; }
        public long? UserId { get; set; }
    }
}
