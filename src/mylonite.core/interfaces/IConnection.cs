using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core.interfaces
{
    public interface IConnection
    {
        bool IsOpened { get; }
        void Open();
        void Close();
    }
}
