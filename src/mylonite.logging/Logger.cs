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

        public ILog GetLog<T>()
        {
            var source = typeof(T).FullName;
            return GetLog(source);
        }

        public ILog GetLog(string source)
        {
            return CONSOLE_LOG;
        }

        public ILog GetLog(string source, string context) { throw new NotImplementedException(); }
    }
}
