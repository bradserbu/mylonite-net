using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.logging.interfaces
{
    public interface ILogProvider
    {
        void WriteEntry(LogEntry entry);
    }
}
