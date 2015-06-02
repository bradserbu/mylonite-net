using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.logging
{
    public class LogEntry
    {
        public string Source { get; private set; }
        public string Context { get; private set; }
        public int Level { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }
    }
}
