using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.logging.interfaces
{
    public interface ILogEntry
    {
        string Source { get; }
        string Context { get; }
        int Level { get; }
        string Message { get; }
        object Data { get; }
    }
}
