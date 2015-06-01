using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.extensions
{
    public static class StringExtensions
    {
        public static string format(this string formatString, params object[] args)
        {
            return String.Format(formatString, args);
        }
    }
}
