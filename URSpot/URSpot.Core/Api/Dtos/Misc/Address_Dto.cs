using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Api.Dtos.Misc
{
    public class Address_Dto 
    {
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public long? CityId { get; set; }

        public long? RegionId { get; set; }

        public string ZipCode { get; set; }

        public long? CountryId { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
