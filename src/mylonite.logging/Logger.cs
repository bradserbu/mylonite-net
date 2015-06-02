using mylonite.logging.interfaces;
using mylonite.logging.providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.logging
{
    public static class Logger
    {
        static readonly ConsoleLogProvider CONSOLE_LOG = new ConsoleLogProvider();

        public static ILog GetLog(Type type)
        {
            var source = type.FullName;
            return GetLog(source);
        }

        static ILog GetLog(string source)
        {
            return CONSOLE_LOG;
        }

        static ILog GetLog(string source, string context) { throw new NotImplementedException(); }
    }
}
