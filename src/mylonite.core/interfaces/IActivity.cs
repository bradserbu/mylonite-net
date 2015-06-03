using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core.interfaces
{
    public interface IActivity : IHasName
    {
        void Run();
        Task RunAsync();

        void OnError(Exception error);
    }
}
