using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Dependencies
{
    public interface IDataBasePath
    {
        String GetDataBasePath();
        bool IsCreated(String DataBaseName);
    }
}
