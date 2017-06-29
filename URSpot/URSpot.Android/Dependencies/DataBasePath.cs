using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using URSpot.Core.Dependencies;
using URSpot.Droid.Dependencies;

[assembly: Xamarin.Forms.Dependency(typeof(DataBasePath))]
namespace URSpot.Droid.Dependencies
{
    public class DataBasePath : IDataBasePath
    {
        public string GetDataBasePath()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        }

        //----------------------------

        public bool IsCreated(String DataBaseName)
        {
            return System.IO.File.Exists(DataBaseName);
        }
    }
}