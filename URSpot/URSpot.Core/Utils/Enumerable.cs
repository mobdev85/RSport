using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Utils
{
    public static class EnumerableExt
    {
        public static string Join(this IEnumerable<string> @this, string sep)
        {
            return string.Join(sep, @this);
        }
        public static void ForEach<T>(this IEnumerable<T> @this, Action<T> a)
        {
            foreach (var item in @this)
            {
                a(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> @this, Action<T, int> a)
        {
            int i = 0;
            foreach (var item in @this)
            {
                a(item, i++ );
            }
        }
    }
}
