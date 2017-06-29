using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Utils
{
    public static class StringUtils
    {
        public static string FormatWith(this string @this, params object[] args)
        {
            return string.Format(@this, args);
        }

        public static int CountWords(string valueText)
        {
            int count = 0;
            bool inWord = false;

            foreach (char t in valueText)
            {
                if (char.IsWhiteSpace(t))
                {
                    inWord = false;
                }
                else
                {
                    if (!inWord) count++;
                    inWord = true;
                }
            }
            return count;
        }
    }
}
