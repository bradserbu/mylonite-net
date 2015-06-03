using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core.interfaces
{
    public interface IJob : IHasName
    {
        void Execute(IActivity activity);
        Task ExecuteAsync(IActivity activity);
    }
}
