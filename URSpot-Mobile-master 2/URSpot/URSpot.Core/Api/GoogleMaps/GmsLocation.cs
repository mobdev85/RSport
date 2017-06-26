using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace CardiApp.Core.Api.GoogleMaps
{
    /// <summary>
    /// Holds latitude longitude
    /// </summary>
    public struct GmsLocation
    {
        /// <summary>
        /// Latitude
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        /// <summary>
        /// Longitude
        /// </summary>
        [JsonProperty("Lng")]
        public double Longitude { get; set; }
        /// <summary>
        /// Convert to position
        /// </summary>
        /// <returns><see cref="Position"/></returns>
        public Position ToPosition()
        {
            return new Position(this.Latitude, this.Longitude);
        }
    }
}
