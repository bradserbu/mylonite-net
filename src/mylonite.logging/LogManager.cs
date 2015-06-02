using mylonite.logging.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.logging
{
    public class LogManager
    {
        ILogger GetLogger<T>() { throw new NotImplementedException(); }

        ILog GetLog(string source) { throw new NotImplementedException(); }
        ILog GetLog(string source, string context) { throw new NotImplementedException(); }
    }
}
