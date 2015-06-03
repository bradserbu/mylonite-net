using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core.interfaces
{
    public interface IActivity : IHasName
    {
        IList<IArgument> Arguments { get; }

        IValue Run(IDictionary<IArgument, IValue> arguments);
        Task<IValue> RunAsync(IDictionary<IArgument, IValue> arguments);

        void OnError(Exception error, Dictionary<IArgument, IValue> arguments);
    }
}
