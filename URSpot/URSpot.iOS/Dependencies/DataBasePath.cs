using System;
using System.Collections.Generic;
using System.Text;
using URSpot.Core.Dependencies;
using URSpot.iOS.Dependencies;

[assembly: Xamarin.Forms.Dependency(typeof(DataBasePath))]
namespace URSpot.iOS.Dependencies
{
    public class DataBasePath : IDataBasePath
    {

        public string GetDataBasePath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }

        //----------------------------

        public bool IsCreated(String DataBaseName)
        {
            bool b = System.IO.File.Exists(DataBaseName);

            return b;
        }
    }
}
