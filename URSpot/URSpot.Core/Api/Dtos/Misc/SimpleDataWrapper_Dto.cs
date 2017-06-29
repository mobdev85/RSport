using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Api.Dtos.Misc
{
    public class SimpleDataWrapper_Dto<T>
    {
        public T Data { get; set; }
    }
}
