using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace URSpot.Core.Utils
{
    public static class XamarinUtils
    {
        public static T FindTemplateElementByName<T>(this Page page, string name)
            where T : Element
        {
            var pc = page as IPageController;
            if (pc == null)
            {
                return null;
            }

            foreach (var child in pc.InternalChildren)
            {
                var result = child.FindByName<T>(name);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
