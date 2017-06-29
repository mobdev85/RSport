using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardiApp.Core.Api.GoogleMaps
{
    /// <summary>
    /// The status returned by the Google places API
    /// </summary>
    public enum GmsDetailsResultStatus
    {
        Ok,
        UnknownError,
        ZeroResults,
        OverQueryLimit,
        RequestDenied,
        InvalidRequest,
        NotFound,
        UnknownStatus
    }
}
